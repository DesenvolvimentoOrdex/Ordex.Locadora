using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
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


        public async Task<List<Aluguel>> ListarAlugueis()
        {
            return await _dbContext.Alugueis
                                   .Include(f => f.Funcionario)
                                   .ThenInclude(f => f.Usuario)
                                   .Include(f => f.Funcionario)
                                   .ThenInclude(e => e.Endereco)                            
                                   .Include(f => f.Cliente)
                                   .ThenInclude(e => e.Usuario)
                                   .Include(f => f.Cliente)
                                   .ThenInclude(e => e.Endereco)
                                   .Include(f => f.Veiculo)
                                   .ToListAsync();

        }

        public async Task<Maybe<Aluguel>> ObterPorId(int id)
        {
            return await _dbContext.Alugueis
                                   .Include(f => f.Funcionario)
                                   .ThenInclude(f => f.Usuario)
                                   .Include(f => f.Funcionario)
                                   .ThenInclude(e => e.Endereco)
                                   .Include(f => f.Cliente)
                                   .ThenInclude(e => e.Usuario)
                                   .Include(f => f.Cliente)
                                   .ThenInclude(e => e.Endereco)
                                   .Include(f => f.Veiculo)
                                    .FirstOrDefaultAsync(c => c.Codigo == id);
        }

        public async Task<Maybe<Aluguel>> ObterPorVeiculo(string placa)
        {
           return await _dbContext.Alugueis
                                  .Include(f => f.Funcionario)
                                   .ThenInclude(f => f.Usuario)
                                   .Include(f => f.Funcionario)
                                   .ThenInclude(e => e.Endereco)
                                   .Include(f => f.Cliente)
                                   .ThenInclude(e => e.Usuario)
                                   .Include(f => f.Cliente)
                                   .ThenInclude(e => e.Endereco)
                                   .Include(f => f.Veiculo)
                                  .FirstOrDefaultAsync(v => v.PlacaVeiculo == placa);
        }
    }
}
