using CSharpFunctionalExtensions;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis
{
    public sealed class AluguelService : IAluguelService
    {
        private readonly IAluguelRepository _aluguelRepository;

        public AluguelService(IAluguelRepository repository)
        {
            _aluguelRepository = repository;
        }

        public async Task<Result<Aluguel>> ObterPorId(int id)
        {
            var aluguel = await _aluguelRepository.ObterPorId(id);
            if (aluguel.HasNoValue)
            {
                return Result.Failure<Aluguel>("Aluguel não encontrado!");
            }
            return Result.Success<Aluguel>(aluguel.Value);
        }

        public async Task<Result<List<Aluguel>>> ObterTodos()=> await _aluguelRepository.ListarAlugueis();
       
    }
}
