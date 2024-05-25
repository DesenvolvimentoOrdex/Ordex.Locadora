using CSharpFunctionalExtensions;
using Microsoft.IdentityModel.Tokens;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Shared;
using Ordex.Locadora.Shared.DTOs;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;

public sealed class CriarFuncionarioCommand : IDomainCommand<Result<FuncionarioViewModel>>
{
    private CriarFuncionarioCommand(string cpfCnpj, string nomeRazao, DateTime dataFiliacao, string telefone, Usuario usuario, Endereco endereco)
    {
        CpfCnpj = cpfCnpj;
        NomeRazao = nomeRazao;
        DataFiliacao = dataFiliacao;
        Telefone = telefone;
        Usuarios = usuario;
        Endereco = endereco;
    }
    public string CpfCnpj { get; private set; }
    public string NomeRazao { get; private set; }
    public DateTime DataFiliacao { get; private set; }
    public string Telefone { get; private set; }
    public Usuario Usuarios { get; private set; }
    public Endereco Endereco { get; private set; }

    public static Result<CriarFuncionarioCommand> Criar(string cpfCnpj, string nomeRazao, DateTime dataFiliacao, 
                                                        string telefone, Usuario usuario, Endereco endereco)
    {
        if (cpfCnpj.IsNullOrEmpty())
            Result.Failure<CriarClienteCommand>("O campo CpfCnpj é obrigatório");
        else if (nomeRazao.IsNullOrEmpty())
            Result.Failure<CriarClienteCommand>("O campo NomeRazao é obrigatório");
        else if (telefone.IsNullOrEmpty())
            Result.Failure<CriarClienteCommand>("O campo telefone é obrigatório");
        else if (usuario.Id.IsNullOrEmpty())
            Result.Failure<CriarClienteCommand>("O campo UsuarioId é obrigatório");
        return
            new CriarFuncionarioCommand(cpfCnpj, nomeRazao, dataFiliacao, telefone, usuario, endereco);
    }
}
