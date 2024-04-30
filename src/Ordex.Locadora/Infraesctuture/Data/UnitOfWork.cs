
using Microsoft.EntityFrameworkCore;

namespace Ordex.Locadora.Infraesctuture.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LocadoraDbContext _context;

        public UnitOfWork(LocadoraDbContext context)
        {
            _context = context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
