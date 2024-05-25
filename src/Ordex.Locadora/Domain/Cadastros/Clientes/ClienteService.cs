using AutoMapper;
using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{

    public sealed class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepo, IMapper mapper)
        {
            _clienteRepo = clienteRepo;
            _mapper = mapper;
        }

        public async Task<Result<ClienteViewModel>> ObterPorCpfCnpj(string cpfCnpj)
        {
            var cliente = await _clienteRepo.ObterPorCpfCnpj(cpfCnpj);
            if (cliente.HasNoValue)
            {
                return Result.Failure<ClienteViewModel>("Cliente não encontrado.");
            }
            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente.Value);
            return clienteViewModel;
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

        public async Task<Result<ClienteViewModel>> ObterPorId(int id)
        {
            var cliente = await _clienteRepo.ObterPorId(id);
            if (cliente.HasNoValue)
            {
                return Result.Failure<ClienteViewModel>("Cliente não encontrado.");
            }
            var clienteViewModel = _mapper.Map<ClienteViewModel>(cliente.Value);
            return clienteViewModel;
        }

        public async Task<Result<List<ClienteViewModel>>> ObterTodos()
        {
            var clientes = await _clienteRepo.ObterTodos();
            var clientesViewModel = _mapper.Map<List<ClienteViewModel>>(clientes);
            return clientesViewModel;
        }
    }
}
