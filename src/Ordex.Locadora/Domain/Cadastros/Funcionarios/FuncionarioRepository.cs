using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Cadastros.Clientes;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios
{
    public class FuncionarioRepository : IRepository<Funcionario>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Funcionario> _funcionario;

        public FuncionarioRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _funcionario = dbContext.Set<Funcionario>();
        }
        public async Task Adicionar(Funcionario entity)
        {
            await _funcionario.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Funcionario entity)
        {
            _funcionario.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Funcionario> ObterPorId(int id) => await _funcionario.FirstAsync(c => c.Codigo == id);

        public async Task<List<Funcionario>> ObterTodos() => await _funcionario.ToListAsync();
    }
}
