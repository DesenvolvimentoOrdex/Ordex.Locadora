using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Commands;


public sealed class AlterarClienteCommand : IDomainCommand<Result<bool>>
{
    private AlterarClienteCommand(int codigo, string cpfCnpj, string nomeRazao, DateTime dataFiliacao, string telefone)
    {
        Codigo = codigo;
        CpfCnpj = cpfCnpj;
        NomeRazao = nomeRazao;
        DataFiliacao = dataFiliacao;
        Telefone = telefone;
    }
    public int Codigo { get; set; }
    public string CpfCnpj { get; private set; }
    public string NomeRazao { get; private set; }
    public DateTime DataFiliacao { get; private set; }
    public string Telefone { get; private set; }

    public static Result<AlterarClienteCommand> Alterar(int codigo, string cpfCnpj, string nomeRazao, DateTime dataFiliacao, string telefone)
    {
        if (cpfCnpj.IsNullOrEmpty())
            Result.Failure<CriarClienteCommand>("O campo CpfCnpj é obrigatório");
        else if (nomeRazao.IsNullOrEmpty())
            Result.Failure<CriarClienteCommand>("O campo NomeRazao é obrigatório");
        else if (telefone.IsNullOrEmpty())
            Result.Failure<CriarClienteCommand>("O campo telefone é obrigatório");
        return
            new AlterarClienteCommand(codigo, cpfCnpj, nomeRazao, dataFiliacao, telefone);
    }
}
