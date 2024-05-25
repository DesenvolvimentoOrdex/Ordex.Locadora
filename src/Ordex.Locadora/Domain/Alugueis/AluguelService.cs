using AutoMapper;
using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.DTOs;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis
{
    public sealed class AluguelService : IAluguelService
    {
        private readonly IAluguelRepository _aluguelRepository;
        private readonly IMapper _mapper;

        public AluguelService(IAluguelRepository repository, IMapper mapper)
        {
            _aluguelRepository = repository;
            _mapper = mapper;
        }

        public async Task<Result<AluguelViewModel>> ObterPorId(int id)
        {
            var aluguel = await _aluguelRepository.ObterPorId(id);
            if (aluguel.HasNoValue)
            {
                return Result.Failure<AluguelViewModel>("Aluguel não encontrado!");
            }
            var aluguelViewModel = _mapper.Map<AluguelViewModel>(aluguel.Value);
            return Result.Success<AluguelViewModel>(aluguelViewModel);
        }
        public async Task<Result<AluguelViewModel>> ObterPorVeiculo(string placa)
        {
            var aluguel = await _aluguelRepository.ObterPorVeiculo(placa);
            if (aluguel.HasNoValue)
            {
                return Result.Failure<AluguelViewModel>("Aluguel não encontrado!");
            }
            var aluguelViewModel = _mapper.Map<AluguelViewModel>(aluguel.Value);
            return Result.Success<AluguelViewModel>(aluguelViewModel);
        }

        public async Task<Result<List<AluguelViewModel>>> ObterTodos()
        {
            var alugueis = await _aluguelRepository.ListarAlugueis();
            var alugueisViewModel = _mapper.Map<List<AluguelViewModel>>(alugueis);
            return Result.Success<List<AluguelViewModel>>(alugueisViewModel);
        }
    }
}
