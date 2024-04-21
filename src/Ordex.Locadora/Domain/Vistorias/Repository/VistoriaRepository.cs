using Microsoft.EntityFrameworkCore;

namespace Ordex.Locadora.Domain.Vistorias.Repository
{
    public class VistoriaRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Vistoria> _vistoria;

        public VistoriaRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _vistoria = dbContext.Set<Vistoria>();
        }
        public async Task Adicionar(Vistoria entity)
        {
            await _vistoria.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Vistoria entity)
        {
            _vistoria.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Vistoria> ObterPorId(int id) => await _vistoria.FirstAsync(c => c.Codigo == id);

        public async Task<List<Vistoria>> ObterPorVeiculo(int id) => await _vistoria.Where(c => c.Codigo == id).ToListAsync();

    }
}
