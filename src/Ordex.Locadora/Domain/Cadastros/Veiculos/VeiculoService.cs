using AutoMapper;
using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos
{
    public sealed class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<Result<VeiculoViewModel>> ObterPorPlaca(string placa)
        {
            var veiculo = await _veiculoRepository.ObterPorPlaca(placa);
            if (veiculo.HasNoValue)
            {
                return Result.Failure<VeiculoViewModel>("Veículo não encontrado!");
            }
            var veiculoViewModel = _mapper.Map<VeiculoViewModel>(veiculo.Value);
            return Result.Success<VeiculoViewModel>(veiculoViewModel);
        }

        public async Task<Result<List<VeiculoViewModel>>> ObterTodos()
        {
            var veiculosList = await _veiculoRepository.ObterTodos();
            var veiculosListViewModel = _mapper.Map<List<VeiculoViewModel>>(veiculosList);
            return veiculosListViewModel;
        }
    }
}