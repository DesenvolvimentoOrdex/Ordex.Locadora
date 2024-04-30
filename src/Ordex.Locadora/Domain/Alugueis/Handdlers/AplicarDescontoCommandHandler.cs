using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Alugueis.Commands;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis.Handdlers
{
    public sealed class AplicarDescontoCommandHandler : IRequestHandler<AplicarDescontoAluguelCommand, Result<bool>>
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AplicarDescontoCommandHandler(IAluguelRepository aluguelRepository, IUnitOfWork unitOfWork)
        {
            _aluguelRepository = aluguelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<bool>> Handle(AplicarDescontoAluguelCommand request, CancellationToken cancellationToken)
        {

            var aluguel = await _aluguelRepository.ObterPorId(request.AluguelCodigo);
            if (aluguel.HasNoValue)
            {
                return Result.Failure<bool>("Aluguel não encontrado.");

            }

            aluguel.Value.CriarDesconto(request.PercentualDesconto);

            await _aluguelRepository.Atualizar(aluguel.Value);

            await _unitOfWork.Commit();

            return Result.Success<bool>(true);

        }
    }
}
