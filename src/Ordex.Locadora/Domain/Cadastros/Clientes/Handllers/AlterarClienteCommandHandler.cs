using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Handllers;

public sealed class AlterarClienteCommandHandler : IRequestHandler<AlterarClienteCommand, Result<bool>>
{
    private readonly IClienteRepository _clienteRepo;

    public AlterarClienteCommandHandler(IClienteRepository clienteRepo)
    {
        _clienteRepo = clienteRepo;
    }
    public async Task<Result<bool>> Handle(AlterarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepo.ObterPorId(request.Codigo);
        if (cliente.HasNoValue)
        {
            return Result.Failure<bool>("Cliente não encontrado.");
        }
        cliente.Value.Telefone = request.Telefone;

        await _clienteRepo.Atualizar(cliente.Value);

        return Result.Success(true);
    }
}
