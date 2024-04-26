using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;
using Ordex.Locadora.Domain.Logon;
using Ordex.Locadora.Infraesctuture.Data;
using Ordex.Locadora.Shared.Interfaces;

namespace Ordex.Locadora.Domain.Cadastros.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LocadoraDbContext _context;

        public ClienteRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Cliente entity)
        {
            await _context.Clientes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Cliente entity)
        {
            _context.Clientes.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<Maybe<Cliente>> ObterPorUsuarioId(string id)=>await _context.Clientes.FirstOrDefaultAsync(c => c.UsuarioId == id);

        public async Task<Maybe<Cliente>> ObterPorCpfCnpj(string cpfCnpj) => await _context.Clientes.FirstOrDefaultAsync(c => c.CpfCnpj == cpfCnpj);

        public async Task<Maybe<Cliente>> ObterPorId(int id) => await _context.Clientes.FirstOrDefaultAsync(c => c.Codigo == id);

        public async Task<List<Cliente>> ObterTodos() => await _context.Clientes.ToListAsync();

    }
}
