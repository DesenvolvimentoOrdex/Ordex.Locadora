using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Alugueis;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IAluguelService
    {
        Task<Result<Aluguel>> ObterPorId(int id);
        Task<Result<List<Aluguel>>> ObterTodos();
    }
}