using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.Roots.Pessoas;
using Ordex.Locadora.Shared.Validations;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{
    public class Cliente : Pessoa
    {
        private Cliente(string cpfCnpj, EnumTipoPessoa tipoPessoa, int enderecoCep, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo, string usuarioId)
                        : base(cpfCnpj, tipoPessoa, enderecoCep, nomeRazao, dataFiliacao, telefone, ativo, usuarioId)
        {
            CpfCnpj = cpfCnpj;
            TipoPessoa = tipoPessoa;
            EnderecoCep = enderecoCep;
            NomeRazao = nomeRazao;
            DataFiliacao = dataFiliacao;
            Telefone = telefone;
            Ativo = ativo;
            UsuarioId = usuarioId;
        }

        public void AtivarInativar(bool statusCliente)
        {
           Ativo = statusCliente;
        }
        public static Result<Cliente> Novo(string cpfCnpj, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo, string usuarioId)
        {
            Result<bool, string> documentoValido;
            EnumTipoPessoa enumTipoPessoa;
            if (cpfCnpj.Length <= 11)
            {
                documentoValido = DocumentoValidation.CpfValidate(cpfCnpj);
                enumTipoPessoa = EnumTipoPessoa.Fisica;
            }
            else
            {
                documentoValido = DocumentoValidation.CnpjValidate(cpfCnpj);
                enumTipoPessoa = EnumTipoPessoa.Juridica;
            }

            if (documentoValido.IsFailure)
            {
                return Result.Failure<Cliente>(documentoValido.Error);
            }

            return new Cliente(cpfCnpj, enumTipoPessoa, 10, nomeRazao, dataFiliacao, telefone, true, usuarioId);
        }
    }
}
