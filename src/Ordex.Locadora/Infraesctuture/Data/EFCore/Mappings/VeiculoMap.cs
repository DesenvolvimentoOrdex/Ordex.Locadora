using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordex.Locadora.Domain.Cadastros.Frotas;

namespace Ordex.Locadora.Infraesctuture.Data.EFCore.Mappings
{
    public sealed class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(c => c.Placa);
        }
    }
}
