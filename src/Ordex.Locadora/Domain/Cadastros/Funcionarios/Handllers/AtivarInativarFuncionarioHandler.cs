using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Handllers;

public sealed class AtivarInativarFuncionarioHandler : IRequestHandler<AtivarInativarFuncionarioCommand, Result<bool>>
{
    private readonly IFuncionarioRepository _funcioanrioRepo;

    public AtivarInativarFuncionarioHandler(IFuncionarioRepository funcionarioRepo)
    {
        _funcioanrioRepo = funcionarioRepo;
    }
    public async Task<Result<bool>> Handle(AtivarInativarFuncionarioCommand request, CancellationToken cancellationToken)
    {
        var funcionario = await _funcioanrioRepo.ObterPorId(request.Codigo);
        if (funcionario.HasNoValue)
        {
            return Result.Failure<bool>("Cliente não encontrado.");
        }
        if (funcionario.Value.Ativo == request.Status)
            return Result.Success(request.Status);

        funcionario.Value.AtivarInativar(request.Status);

        await _funcioanrioRepo.Atualizar(funcionario.Value);

        return Result.Success(request.Status);

    }
}
