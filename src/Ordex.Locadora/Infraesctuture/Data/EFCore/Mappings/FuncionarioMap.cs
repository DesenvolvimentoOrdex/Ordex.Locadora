using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordex.Locadora.Domain.Cadastros.Funcionarios;

namespace Ordex.Locadora.Infraesctuture.Data.EFCore.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(c => new { c.Codigo });
        }
    }
}
