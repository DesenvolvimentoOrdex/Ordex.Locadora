using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Veiculos.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos.Handllers
{
    public sealed class AlterarVeiculoCommandHandler : IRequestHandler<CriarVeiculoCommand, Result<Veiculo>>
    {
        private readonly IVeiculoRepository _veiculoRepo;

        public AlterarVeiculoCommandHandler(IVeiculoRepository veiculoRepo)
        {
            _veiculoRepo = veiculoRepo;
        }
        public async Task<Result<Veiculo>> Handle(CriarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepo.ObterPorPlaca(request.Placa);
            if (veiculo.HasNoValue)
            {
                return Result.Failure<Veiculo>("Veículo não encontrado!");
            }

            veiculo.Value.AlterarDados(request.Marca, request.Modelo, request.Ano, request.Cor, request.Valor, request.Renavam, request.Chassi);
        
            await _veiculoRepo.Adicionar(veiculo.Value);

            return Result.Success<Veiculo>(veiculo.Value);
        }
    }
}
