using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ordex.Locadora.Infraesctuture.Data.EFCore.Mappings
{
    public sealed class IdentityUserMap : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
