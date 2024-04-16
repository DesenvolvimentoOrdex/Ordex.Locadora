using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Alugueis
{
    public class AluguelRepository : IRepository<Aluguel>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Aluguel> _aluguel;

        public AluguelRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _aluguel = dbContext.Set<Aluguel>();
        }
        public async Task Adicionar(Aluguel entity)
        {
            await _aluguel.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Aluguel entity)
        {
            _aluguel.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Aluguel> ObterPorId(int id) => await _aluguel.FirstAsync(c => c.Codigo == id);

        public async Task<List<Aluguel>> ListarAlugueis() => await _aluguel.ToListAsync();
    }
}
