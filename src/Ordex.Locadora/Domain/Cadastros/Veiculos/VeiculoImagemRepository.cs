using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos
{
    public class VeiculoImagemRepository : IRepository<VeiculoImagem>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<VeiculoImagem> _veiculo;

        public VeiculoImagemRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _veiculo = dbContext.Set<VeiculoImagem>();
        }
        public async Task Adicionar(VeiculoImagem entity)
        {
            await _veiculo.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(VeiculoImagem entity)
        {
            _veiculo.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<VeiculoImagem>> ObterPorVeiculo(string placa) => await _veiculo.Where(c => c.Placa == placa).ToListAsync();
    }
}
