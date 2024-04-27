using CSharpFunctionalExtensions;
using Ordex.Locadora.Domain.Alugueis;

namespace Ordex.Locadora.Shared.Interfaces
{
    public interface IAluguelRepository
    {
        Task Adicionar(Aluguel entity);
        Task Atualizar(Aluguel entity);
        Task<List<Aluguel>> ListarAlugueis();
        Task<Maybe<Aluguel>> ObterPorId(int id);
        Task<Maybe<Aluguel>> ObterPorVeiculo(string placa);

    }
}