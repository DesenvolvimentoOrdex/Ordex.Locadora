using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Alugueis.Commands;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis.Handdlers
{
    public sealed class DeletarAluguelCommandHandler : IRequestHandler<DeletarAluguelCommand, Result<bool>>
    {

        private readonly IAluguelRepository _aluguelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeletarAluguelCommandHandler(IAluguelRepository aluguelRepository, IUnitOfWork unitOfWork)
        {
            _aluguelRepository = aluguelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(DeletarAluguelCommand request, CancellationToken cancellationToken)
        {
            var aluguel = await _aluguelRepository.ObterPorId(request.AluguelCodigo);
            if (aluguel.HasNoValue)
            {
                return Result.Failure<bool>("Aluguel não encontrado.");

            }

            if (aluguel.Value.Status != EnumStatusAluguel.Aberto || (aluguel.Value.Status !=  EnumStatusAluguel.fechado))
            {
                return Result.Failure<bool>("Não é permitido excluir aluguel com status diferente de rascuho!.");
            }
            await _aluguelRepository.Remover(aluguel.Value);

            await _unitOfWork.Commit();

            return Result.Success<bool>(true);
        }
    }
}
