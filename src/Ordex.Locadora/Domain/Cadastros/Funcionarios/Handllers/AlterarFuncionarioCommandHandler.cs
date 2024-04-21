using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Handllers
{
    public sealed class AlterarFuncionarioCommandHandler : IRequestHandler<AlterarFuncionarioCommand, Result<bool>>
    {
        private readonly IFuncionarioRepository _funcioanrioRepo;

        public AlterarFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepo)
        {
            _funcioanrioRepo = funcionarioRepo;
        }
        public async Task<Result<bool>> Handle(AlterarFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = await _funcioanrioRepo.ObterPorId(request.Codigo);
            if (funcionario.HasNoValue)
            {
                return Result.Failure<bool>("Cliente não encontrado.");
            }
            funcionario.Value.Telefone = request.Telefone;

            await _funcioanrioRepo.Atualizar(funcionario.Value);

            return Result.Success(true);
        }
    }
}
