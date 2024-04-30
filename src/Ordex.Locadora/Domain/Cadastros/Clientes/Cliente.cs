using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Shared.Roots.Pessoas;
using Ordex.Locadora.Shared.Validations;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{
    public class Cliente : Pessoa
    {
        public Endereco Endereco { get; private set; }

        private Cliente(string cpfCnpj, EnumTipoPessoa tipoPessoa, string nomeRazao, DateTime dataFiliacao, 
                        string telefone, bool ativo, string usuarioId): base(cpfCnpj, tipoPessoa, nomeRazao, dataFiliacao, 
                                                                             telefone, ativo, usuarioId)
        {
            CpfCnpj = cpfCnpj;
            TipoPessoa = tipoPessoa;
            NomeRazao = nomeRazao;
            DataFiliacao = dataFiliacao;
            Telefone = telefone;
            Ativo = ativo;
            UsuarioId = usuarioId;
        }
        public void IncluirEdereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void AtivarInativar(bool statusCliente)
        {
           Ativo = statusCliente;
        }

        public void Atualizar(AlterarClienteCommand request)
        {
            NomeRazao = request.NomeRazao;
            DataFiliacao = request.DataFiliacao;
            Telefone = request.Telefone;

            if (Endereco == null)
            {
                Endereco = Endereco.Novo(request.Endereco.Cep, request.Endereco.Logadouro,
                                         request.Endereco.Numero, request.Endereco.Bairro,
                                         request.Endereco.Cidade, request.Endereco.UF);
            }
            else
            {
                Endereco.Cep = request.Endereco.Cep;
                Endereco.Logadouro = request.Endereco.Logadouro;
                Endereco.Numero = request.Endereco.Numero;
                Endereco.Bairro = request.Endereco.Bairro;
                Endereco.Cidade = request.Endereco.Cidade;
                Endereco.UF = request.Endereco.UF;

            }
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

            return new Cliente(cpfCnpj, enumTipoPessoa, nomeRazao, dataFiliacao, telefone, true, usuarioId);
        }
    }
}
