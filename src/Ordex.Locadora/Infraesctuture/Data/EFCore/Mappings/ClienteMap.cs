
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordex.Locadora.Domain.Cadastros.Clientes;

namespace Ordex.Locadora.Infraesctuture.Data.EFCore.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => new { c.Codigo });
        }

    }
}
