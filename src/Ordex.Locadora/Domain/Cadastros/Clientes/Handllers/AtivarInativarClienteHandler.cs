using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Handllers
{
    public sealed class AtivarInativarClienteHandler : IRequestHandler<AtivarInativarClienteCommand, Result<bool>>
    {
        private readonly IClienteRepository _clienteRepo;

        public AtivarInativarClienteHandler(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }
        public async Task<Result<bool>> Handle(AtivarInativarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepo.ObterPorId(request.Codigo);
            if (cliente.HasNoValue)
            {
                return Result.Failure<bool>("Cliente não encontrado.");
            }
            if (cliente.Value.Ativo == request.Status)
                return Result.Success(request.Status);

            cliente.Value.AtivarInativar(request.Status);

            await _clienteRepo.Atualizar(cliente.Value);

            return Result.Success(request.Status);

        }
    }
}
