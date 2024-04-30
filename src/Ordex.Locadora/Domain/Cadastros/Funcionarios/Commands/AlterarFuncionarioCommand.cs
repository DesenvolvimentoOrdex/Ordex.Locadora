using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;

public sealed class AlterarFuncionarioCommand : IDomainCommand<Result<bool>>
{
    private AlterarFuncionarioCommand(int codigo, string nomeRazao, DateTime dataFiliacao, string telefone, Endereco endereco)
    {
        Codigo = codigo;
        NomeRazao = nomeRazao;
        DataFiliacao = dataFiliacao;
        Telefone = telefone;
        Endereco = endereco;
    }
    public int Codigo { get; set; }
 
    public string NomeRazao { get; private set; }
    public DateTime DataFiliacao { get; private set; }
    public string Telefone { get; private set; }
    public Endereco Endereco {  get; private set; }


    public static Result<AlterarFuncionarioCommand> Alterar(int codigo, string nomeRazao,
                                                            DateTime dataFiliacao, string telefone, Endereco endereco)
    {
        if (nomeRazao.IsNullOrEmpty())
            Result.Failure<AlterarFuncionarioCommand>("O campo NomeRazao é obrigatório");
        else if (telefone.IsNullOrEmpty())
            Result.Failure<AlterarFuncionarioCommand>("O campo telefone é obrigatório");
        return
            new AlterarFuncionarioCommand(codigo, nomeRazao, dataFiliacao, telefone, endereco);
    }
}
