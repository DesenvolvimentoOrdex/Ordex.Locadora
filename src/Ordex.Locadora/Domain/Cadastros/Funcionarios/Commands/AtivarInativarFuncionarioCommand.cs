using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;

public sealed class AtivarInativarFuncionarioCommand:IDomainCommand<Result<bool>>
{
    private AtivarInativarFuncionarioCommand(int codigo, bool status)
    {
        Codigo = codigo;
        Status = status;
    }

    public int Codigo { get; set; }
    public bool Status { get; set; }

    public static Result<AtivarInativarFuncionarioCommand> Ativar(int codigo, bool status = true)
    {
        return new AtivarInativarFuncionarioCommand(codigo, status);
    }

    public static Result<AtivarInativarFuncionarioCommand> Inativar(int codigo, bool status = false)
    {
        return new AtivarInativarFuncionarioCommand(codigo, status);
    }
}
