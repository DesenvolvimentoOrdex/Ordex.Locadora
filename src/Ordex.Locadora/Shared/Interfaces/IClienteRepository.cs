using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IClienteRepository
    {
        Task Adicionar(Cliente entity);
        Task Atualizar(Cliente entity);
        Task<List<Cliente>> ObterTodos();
        Task<Maybe<Cliente>> ObterPorId(int id);
        Task<Maybe<Cliente>> ObterPorCpfCnpj(string cpfCnpj);
        Task<Maybe<Cliente>> ObterPorUsuarioId(string id);
    }
}