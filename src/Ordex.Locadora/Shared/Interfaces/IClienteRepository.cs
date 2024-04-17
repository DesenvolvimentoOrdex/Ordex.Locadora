using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<List<Cliente>> ObterTodos();
        Task<Maybe<Cliente>> ObterPorId(int id);
        Task<Maybe<Cliente>> ObterPorEmail(string email);
    }
}