using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared;

namespace Ordex.Locadora.Domain.Alugueis.Commands
{
    public sealed class AplicarDescontoAluguelCommand :IDomainCommand<Result<bool>>
    {

        private AplicarDescontoAluguelCommand(int percentual, int aluguelCodigo)
        {

            PercentualDesconto = percentual;
            AluguelCodigo = aluguelCodigo;
        }
        public int AluguelCodigo { get; private set; }
        public int PercentualDesconto {  get; private set; }
        public static Result<AplicarDescontoAluguelCommand> Criar( int percentual, int aluguelCodigo)
        {
            if (percentual == 0)
            {
                Result.Failure<AplicarDescontoAluguelCommand>("O campo percentual não pode ser 0.");
            }
            return new AplicarDescontoAluguelCommand(percentual, aluguelCodigo);
        }
    }
}
