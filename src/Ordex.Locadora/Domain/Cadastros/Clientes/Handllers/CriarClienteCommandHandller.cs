using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Handllers
{
    public sealed class CriarClienteCommandHandller : IRequestHandler<CriarClienteCommand, Result<int>>
    {
        private readonly IClienteRepository _clienteRepo;

        public CriarClienteCommandHandller(IClienteRepository repo)
        {
            _clienteRepo = repo;
        }
        public async Task<Result<int>> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepo.ObterPorEmail(request.Email);

            return 1;


        }
    }
}
