using CSharpFunctionalExtensions;
using MediatR;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Veiculos.Commands;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos.Handllers
{
    public sealed class CriarVeiculoCommandHandler : IRequestHandler<CriarVeiculoCommand, Result<Veiculo>>
    {
        private readonly IVeiculoRepository _veiculoRepo;

        public CriarVeiculoCommandHandler(IVeiculoRepository veiculoRepo)
        {
            _veiculoRepo = veiculoRepo;
        }

        public async Task<Result<Veiculo>> Handle(CriarVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepo.ObterPorPlaca(request.Placa);
            if (veiculo.HasValue)
            {
                return Result.Failure<Veiculo>("Veículo já possui cadastro!");
            }

            var veiculoNovo = Veiculo.Novo(request.Placa, request.Marca, request.Modelo, request.Ano, request.Cor, request.Valor, request.Renavam, request.Chassi);

            await _veiculoRepo.Adicionar(veiculoNovo);

            return Result.Success<Veiculo>(veiculoNovo);
        }
    }
}
