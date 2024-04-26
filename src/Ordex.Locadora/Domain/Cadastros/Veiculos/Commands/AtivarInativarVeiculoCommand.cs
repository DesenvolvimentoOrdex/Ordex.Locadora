using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Commands
{
    public class AtivarInativarVeiculoCommand : IDomainCommand<Result<bool>>
    {
        public AtivarInativarVeiculoCommand(string placa, bool status)
        {
            Placa = placa;
            Status = status;
        }

        public string Placa { get; set; }
        public bool Status { get; set; }

        public static Result<AtivarInativarVeiculoCommand> Ativar(string placa, bool status = true)
        {
            return new AtivarInativarVeiculoCommand(placa, status);
        }

        public static Result<AtivarInativarVeiculoCommand> Inativar(string placa, bool status = false)
        {
            return new AtivarInativarVeiculoCommand(placa, status);
        }
    }
}
