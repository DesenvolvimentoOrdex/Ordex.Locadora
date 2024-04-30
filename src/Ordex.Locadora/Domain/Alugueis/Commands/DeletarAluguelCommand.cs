using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Alugueis.Commands
{
    public sealed class DeletarAluguelCommand : IDomainCommand<Result<bool>>
    {
        private  DeletarAluguelCommand(int aluguelCodigo)
        {
            AluguelCodigo = aluguelCodigo;
        }

        public int AluguelCodigo { get; set; }

        public static Result<DeletarAluguelCommand> Remover(int aluguelCodigo)
        {
            
            return new DeletarAluguelCommand(aluguelCodigo);
        }
    }
}
