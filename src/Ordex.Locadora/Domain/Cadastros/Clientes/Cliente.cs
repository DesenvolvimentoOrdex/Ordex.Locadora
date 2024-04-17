using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using Ordex.Locadora.Shared.Roots.Pessoas;
using Ordex.Locadora.Shared.Validations;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{
    public class Cliente : Pessoa
    {
        private Cliente(string cpfCnpj, EnumTipoPessoa tipoPessoa, int enderecoCep, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo)
                        : base(cpfCnpj, tipoPessoa, enderecoCep, nomeRazao, dataFiliacao, telefone, ativo)
        {
            CpfCnpj = cpfCnpj;
            TipoPessoa = tipoPessoa;
            EnderecoCep = enderecoCep;
            NomeRazao = nomeRazao;
            DataFiliacao = dataFiliacao;
            Telefone = telefone;
            Ativo = ativo;
        }

        public bool AtivarInativar(bool statusCliente)
        {
            if (statusCliente)
                statusCliente = false;
            else
                statusCliente = true;

            return statusCliente;
        }
        public static Result<Cliente> Novo(string cpfCnpj, EnumTipoPessoa tipoPessoa, int enderecoCep, string nomeRazao, DateTime dataFiliacao, string telefone, bool ativo)
        {
            var cpfCnpjResult = "";
            if (tipoPessoa == EnumTipoPessoa.Juridica)
                cpfCnpjResult = DocumentoValidation.CnpjValidate(cpfCnpj).Error;
            else
                cpfCnpjResult = DocumentoValidation.CpfValidate(cpfCnpj).Error;

            return !cpfCnpjResult.IsNullOrEmpty() ? new Cliente(cpfCnpj, tipoPessoa, enderecoCep, nomeRazao, dataFiliacao, telefone, true) : Result.Failure<Cliente>(cpfCnpjResult);
        }
    }
}
