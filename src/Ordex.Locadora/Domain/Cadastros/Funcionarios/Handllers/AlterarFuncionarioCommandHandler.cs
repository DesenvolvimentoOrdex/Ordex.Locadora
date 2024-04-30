using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Enderecos;
using Ordex.Locadora.Domain.Cadastros.Funcionarios.Commands;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios.Handllers
{
    public sealed class AlterarFuncionarioCommandHandler : IRequestHandler<AlterarFuncionarioCommand, Result<bool>>
    {
        private readonly IFuncionarioRepository _funcionarioRepo;
        private readonly IUnitOfWork _unitOfWork;

        public AlterarFuncionarioCommandHandler(IFuncionarioRepository funcionarioRepo, IUnitOfWork unitOfWork)
        {
            _funcionarioRepo = funcionarioRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(AlterarFuncionarioCommand request, CancellationToken cancellationToken)
        {
            var funcionario = await _funcionarioRepo.ObterPorId(request.Codigo);
            if (funcionario.HasNoValue)
            {
                return Result.Failure<bool>("Cliente não encontrado.");
            }
            var userId = funcionario.Value.Usuario.Id;

            funcionario.Value.Atualizar(request);

            await _funcionarioRepo.Atualizar(funcionario.Value);

            await _unitOfWork.Commit();

            return Result.Success(true);
        }
    }
}
