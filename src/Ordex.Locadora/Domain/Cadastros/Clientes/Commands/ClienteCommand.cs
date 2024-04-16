using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Commands
{
    public class ClienteCommand : IDomainCommand<Result>
    {

        public static Result<AlterarVencimentoCommand> Criar(DateTime novoVencimento)
        {
            return
                novoVencimento <= DateTime.UtcNow
                    ? Result.Failure<AlterarVencimentoCommand>("Novo vencimento inválido")
                    : new AlterarVencimentoCommand(Guid.NewGuid(), DateTime.UtcNow, novoVencimento);
        }
    }
}
