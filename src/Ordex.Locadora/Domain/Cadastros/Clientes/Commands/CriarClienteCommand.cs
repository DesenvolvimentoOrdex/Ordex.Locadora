using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Commands
{
    public class CriarClienteCommand : IDomainCommand<Result<int>>
    {
        private  CriarClienteCommand(string email, string cpfCnpj, string nomeRazao, DateTime dataFiliacao, string telefone)
        {
            Email = email;
            CpfCnpj = cpfCnpj;
            NomeRazao = nomeRazao;
            DataFiliacao = dataFiliacao;
            Telefone = telefone;
        }
        public string Email { get; private set; }
        public string CpfCnpj { get; private set; }
        public string NomeRazao { get; private set; }
        public DateTime DataFiliacao { get; private set; }
        public string Telefone { get; private set; }

        public static Result<CriarClienteCommand> Criar(string email, string cpfCnpj, string nomeRazao, DateTime dataFiliacao, string telefone)
        {
            if (email.IsNullOrEmpty())
                Result.Failure<CriarClienteCommand>("O campo Emial é obrigatório");
            if (cpfCnpj.IsNullOrEmpty())
                Result.Failure<CriarClienteCommand>("O campo CpfCnpj é obrigatório");
            else if (nomeRazao.IsNullOrEmpty())
                Result.Failure<CriarClienteCommand>("O campo NomeRazao é obrigatório");
            else if (telefone.IsNullOrEmpty())
                Result.Failure<CriarClienteCommand>("O campo telefone é obrigatório");
            return
                new CriarClienteCommand(email, cpfCnpj, nomeRazao, dataFiliacao, telefone);           
        }
    }
}
