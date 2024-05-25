using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.DTOs;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IVeiculoService
    {
        Task<Result<VeiculoViewModel>> ObterPorPlaca(string placa);
        Task<Result<List<VeiculoViewModel>>> ObterTodos();
    }
}