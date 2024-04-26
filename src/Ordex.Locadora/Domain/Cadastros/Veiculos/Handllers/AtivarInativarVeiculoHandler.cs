using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Clientes.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos.Handllers
{
    public sealed class AtivarInativarVeiculoHandler : IRequestHandler<AtivarInativarVeiculoCommand, Result<bool>>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public AtivarInativarVeiculoHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Result<bool>> Handle(AtivarInativarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.ObterPorPlaca(request.Placa);
            if (veiculo.HasNoValue)
            {
                return Result.Failure<bool>("Veículo não encontrado.");
            }
            if (veiculo.Value.Ativo == request.Status)
                return Result.Success(request.Status);

            veiculo.Value.AtivarInativar(request.Status);

            await _veiculoRepository.Atualizar(veiculo.Value);

            return Result.Success(request.Status);
        }
    }
}
