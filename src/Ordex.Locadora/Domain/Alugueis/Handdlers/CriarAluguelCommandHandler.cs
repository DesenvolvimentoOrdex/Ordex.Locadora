using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Alugueis.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis.Handdlers
{
    public sealed class CriarAluguelCommandHandler : IRequestHandler<CriarAluguelCommand, Result<Aluguel>>
    {
        private readonly IAluguelRepository _aluguelRepository;

        public CriarAluguelCommandHandler(IAluguelRepository aluguelRepository)
        {
            _aluguelRepository = aluguelRepository;
        }

        public async Task<Result<Aluguel>> Handle(CriarAluguelCommand request, CancellationToken cancellationToken)
        {
            var aluguel = await _aluguelRepository.ObterPorVeiculo(request.PlacaVeiculo);
            if (aluguel.HasValue)
            {
                if (aluguel.Value.Status)
                {
                    return Result.Failure<Aluguel>($"Existe um aluguel em andamento para o veiculo:{request.PlacaVeiculo}");
                }
            }
            var aluguelNovo = Aluguel.Novo(request.CodigoCliente, request.CodigoFuncionario, request.PlacaVeiculo, request.Valor, request.PossuiDesconto);

            if (request.PossuiDesconto)
            {
                aluguelNovo.CriarDesconto(request.PercentualDesconto);
            }
            await _aluguelRepository.Adicionar(aluguelNovo);

            return Result.Success<Aluguel>(aluguelNovo);
        }
    }
}
