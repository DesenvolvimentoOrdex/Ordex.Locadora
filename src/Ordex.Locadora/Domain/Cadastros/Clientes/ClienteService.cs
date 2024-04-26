using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{

    public sealed class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepo;

        public ClienteService(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public async Task<Result<Cliente>> ObterPorCpfCnpj(string cpfCnpj)
        {
            var cliente = await _clienteRepo.ObterPorCpfCnpj(cpfCnpj);
            if (cliente.HasNoValue)
            {
                return Result.Failure<Cliente>("Cliente não encontrado.");
            }
            return cliente.Value;
        }

        public async Task<Result<bool>> ExisteCpfCnpj(string cpfCnpj)
        {
            var cliente = await _clienteRepo.ObterPorCpfCnpj(cpfCnpj);
            if (cliente.HasValue)
            {
                return Result.Failure<bool>("CpfCnpj em uso.");
            }
            return Result.Success<bool>(false);
        }

        public async Task<Result<Cliente>> ObterPorId(int id)
        {
            var cliente = await _clienteRepo.ObterPorId(id);
            if (cliente.HasNoValue)
            {
                return Result.Failure<Cliente>("Cliente não encontrado.");
            }
            return cliente.Value;
        }

        public async Task<Result<List<Cliente>>> ObterTodos()
        {
            return await _clienteRepo.ObterTodos();
        }
    }
}
