using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Shared.DTOs;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IClienteService
    {
        Task<Result<ClienteViewModel>> ObterPorId(int id);
        Task<Result<ClienteViewModel>> ObterPorCpfCnpj(string cpfCnpj);
        Task<Result<bool>> ExisteCpfCnpj(string cpfCnpj);
        Task<Result<List<ClienteViewModel>>> ObterTodos();

    }
}