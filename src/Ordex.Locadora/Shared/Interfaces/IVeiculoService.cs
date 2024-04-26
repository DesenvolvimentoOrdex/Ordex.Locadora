using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Frotas;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IVeiculoService
    {
        Task<Result<Veiculo>> ObterPorPlaca(string placa);
        Task<Result<List<Veiculo>>> ObterTodos();
    }
}