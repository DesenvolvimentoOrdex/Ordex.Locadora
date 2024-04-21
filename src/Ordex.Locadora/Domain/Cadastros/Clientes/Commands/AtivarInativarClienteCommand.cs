using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Commands
{
    public class AtivarInativarClienteCommand : IDomainCommand<Result<bool>>
    {
        private AtivarInativarClienteCommand(int codigo, bool status)
        {
            Codigo = codigo;
            Status = status;
        }

        public int Codigo { get; set; }
        public bool Status { get; set; }

        public static Result<AtivarInativarClienteCommand> Ativar(int codigo, bool status=true)
        {
            return new AtivarInativarClienteCommand(codigo, status);
        }

        public static Result<AtivarInativarClienteCommand> Inativar(int codigo, bool status=false)
        {
            return new AtivarInativarClienteCommand(codigo, status);
        }
    }
}
