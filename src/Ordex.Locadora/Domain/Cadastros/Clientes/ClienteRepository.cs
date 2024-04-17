using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<Cliente> _cliente;

        public ClienteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _cliente = dbContext.Set<Cliente>();
        }
        public async Task Adicionar(Cliente entity)
        {
            await _cliente.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Atualizar(Cliente entity)
        {
            _cliente.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Maybe<Cliente>> ObterPorEmail(string email) => await _cliente.Where(c => c.Usuario.Email == email).FirstAsync();

        public async Task<Maybe<Cliente>> ObterPorId(int id) => await _cliente.FirstAsync(c => c.Codigo == id);

        public async Task<List<Cliente>> ObterTodos() => await _cliente.ToListAsync();
    }
}
