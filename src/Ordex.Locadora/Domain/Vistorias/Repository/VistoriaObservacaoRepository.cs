using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Vistorias;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Vistorias.Repository
{
    public class VistoriaObservacaoRepository : IRepository<VistoriaObservacao>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<VistoriaObservacao> _vistoria;

        public VistoriaObservacaoRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _vistoria = dbContext.Set<VistoriaObservacao>();
        }
        public async Task Adicionar(VistoriaObservacao entity)
        {
            await _vistoria.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(VistoriaObservacao entity)
        {
            _vistoria.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<VistoriaObservacao> ObterPorId(int id) => await _vistoria.FirstAsync(c => c.Codigo == id);

        public async Task<List<VistoriaObservacao>> ObterPorVeiculo(int id) => await _vistoria.Where(c => c.Codigo == id).ToListAsync();

    }
}
