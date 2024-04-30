using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes.Handllers;

public sealed class AlterarClienteCommandHandler : IRequestHandler<AlterarClienteCommand, Result<bool>>
{
    private readonly IClienteRepository _clienteRepo;
    private readonly IUnitOfWork _unitOfWork;

    public AlterarClienteCommandHandler(IClienteRepository clienteRepo, IUnitOfWork unitOfWork)
    {
        _clienteRepo = clienteRepo;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> Handle(AlterarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepo.ObterPorId(request.Codigo);
        if (cliente.HasNoValue)
        {
            return Result.Failure<bool>("Cliente não encontrado.");
        }

        cliente.Value.Atualizar(request);

        await _clienteRepo.Atualizar(cliente.Value);

        await _unitOfWork.Commit();

        return Result.Success(true);
    }
}
