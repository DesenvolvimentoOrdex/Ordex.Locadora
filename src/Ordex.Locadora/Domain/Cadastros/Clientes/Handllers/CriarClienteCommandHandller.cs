using AutoMapper;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.ValueTasks;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Handllers
{
    public sealed class CriarClienteCommandHandller : IRequestHandler<CriarClienteCommand, Result<ClienteViewModel>>
    {

        private readonly IClienteRepository _clienteRepo;
        private readonly IMapper _mapper;
 
        public CriarClienteCommandHandller(IClienteRepository clienteRepo, IMapper mapper)
        {
            _clienteRepo = clienteRepo;
            _mapper = mapper;
        }

        public async Task<Result<ClienteViewModel>> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var clientex = await _clienteRepo.ObterPorUsuarioId(request.Usuarios.Id);
            if (clientex.HasValue)
            {
                return Result.Failure<ClienteViewModel>($" Este endereço de email está em uso, verifique!");
            }

            var existeCpfCnpj = await _clienteRepo.ObterPorCpfCnpj(request.CpfCnpj);
            if (existeCpfCnpj.HasValue)
            {
                return Result.Failure<ClienteViewModel>($" Cpf ou Cnpj cadastrado para o cliente com o codigo: {existeCpfCnpj.Value.Codigo}, verifique!");
            }

            var clienteNovo = Cliente.Novo(request.CpfCnpj, request.NomeRazao, request.DataFiliacao, request.Telefone, true, request.Usuarios.Id);
            if (clienteNovo.IsFailure)
            {
                return Result.Failure<ClienteViewModel>(clienteNovo.Error);
            }

            clienteNovo.Value.IncluirEdereco(request.Endereco);

            await _clienteRepo.Adicionar(clienteNovo.Value);

            var clienteCadastrado = await _clienteRepo.ObterPorId(clienteNovo.Value.Codigo);
            if (clienteCadastrado.HasNoValue)
            {
                return Result.Failure<ClienteViewModel>($" Fallha ao cadastrar Cliente.");
            }

            var clienteViewModel = _mapper.Map<ClienteViewModel>(clienteCadastrado.Value);
            return clienteViewModel;
        }
    }
}
