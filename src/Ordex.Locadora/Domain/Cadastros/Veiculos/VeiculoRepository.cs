using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Cadastros.Frotas;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Veiculos
{
    public class VeiculoRepository: IVeiculoRepository
    {
        private readonly LocadoraDbContext _dbContext;

        public VeiculoRepository(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Adicionar(Veiculo entity)
        {
            await _dbContext.Veiculos.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Veiculo entity)
        {
            _dbContext.Veiculos.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Maybe<Veiculo>> ObterPorPlaca(string placa) => await _dbContext.Veiculos.FirstOrDefaultAsync(c => c.Placa == placa);

        public async Task<List<Veiculo>> ObterTodos() => await _dbContext.Veiculos.ToListAsync();
    }
}