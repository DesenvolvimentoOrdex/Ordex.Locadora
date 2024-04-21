using Microsoft.EntityFrameworkCore;

namespace Ordex.Locadora.Domain.Vistorias.Repository
{
    public class VistoriaImagemRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<VistoriaImagem> _vistoria;

        public VistoriaImagemRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _vistoria = dbContext.Set<VistoriaImagem>();
        }
        public async Task Adicionar(VistoriaImagem entity)
        {
            await _vistoria.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(VistoriaImagem entity)
        {
            _vistoria.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<VistoriaImagem>> ObterPorVeiculo(int id) => await _vistoria.Where(c => c.CodigoVistoria == id).ToListAsync();
    }
}
