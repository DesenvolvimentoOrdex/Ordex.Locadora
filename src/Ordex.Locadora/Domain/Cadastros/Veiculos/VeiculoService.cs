using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos
{
    public sealed class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<Result<Veiculo>> ObterPorPlaca(string placa)
        {
            var veiculo = await _veiculoRepository.ObterPorPlaca(placa);
            if (veiculo.HasNoValue)
            {
                return Result.Failure<Veiculo>("Veículo não encontrado!");
            }
            return Result.Success<Veiculo>(veiculo.Value);
        }

        public async Task<Result<List<Veiculo>>> ObterTodos() => await _veiculoRepository.ObterTodos();
    }
}