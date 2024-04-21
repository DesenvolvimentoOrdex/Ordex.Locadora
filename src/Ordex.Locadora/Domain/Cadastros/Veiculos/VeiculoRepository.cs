using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos
{
    public class VeiculoRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Veiculo> _veiculo;

        public VeiculoRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _veiculo = dbContext.Set<Veiculo>();
        }
        public async Task Adicionar(Veiculo entity)
        {
            await _veiculo.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Veiculo entity)
        {
            _veiculo.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Veiculo> ObterPorId(string placa) => await _veiculo.FirstAsync(c => c.Placa == placa);

        public async Task<List<Veiculo>> ObterTodos() => await _veiculo.ToListAsync();
    }
}