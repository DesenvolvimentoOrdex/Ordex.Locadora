using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis
{
    public class AluguelRepository : IAluguelRepository
    {
        private readonly LocadoraDbContext _dbContext;

        public AluguelRepository(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Adicionar(Aluguel entity)
        {
            await _dbContext.Alugueis.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Aluguel entity)
        {
            _dbContext.Alugueis.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remover(Aluguel entity)
        {
            _dbContext.Alugueis.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<Aluguel>> ListarAlugueis() => await _dbContext.Alugueis.ToListAsync();

        public async Task<Maybe<Aluguel>> ObterPorId(int id) => await _dbContext.Alugueis.FirstOrDefaultAsync(c => c.Codigo == id);

        public async Task<Maybe<Aluguel>> ObterPorVeiculo(string placa)=>await _dbContext.Alugueis.FirstOrDefaultAsync(v => v.PlacaVeiculo == placa);
    }
}
