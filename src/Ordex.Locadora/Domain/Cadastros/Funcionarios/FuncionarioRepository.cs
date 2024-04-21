using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Funcionarios
{
    public class FuncionarioRepository: IFuncionarioRepository
    {
        private readonly LocadoraDbContext _dbContext;

        public FuncionarioRepository(LocadoraDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Adicionar(Funcionario entity)
        {
            await _dbContext.Funcionarios.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Funcionario entity)
        {
            _dbContext.Funcionarios.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Maybe<Funcionario>> ObterPorId(int id) => await _dbContext.Funcionarios.FirstOrDefaultAsync(c => c.Codigo == id);

        public async Task<Maybe<Funcionario>> ObterPorUsuarioId(string id) => await _dbContext.Funcionarios.FirstOrDefaultAsync(c => c.UsuarioId == id);
       
        public async Task<List<Funcionario>> ObterTodos() => await _dbContext.Funcionarios.ToListAsync();

    }
}
