using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Frotas;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<List<Veiculo>> ObterTodos();
        Task<Maybe<Veiculo>> ObterPorPlaca(string placa);
        Task Adicionar(Veiculo entity);
        Task Atualizar(Veiculo entity);
    }
}