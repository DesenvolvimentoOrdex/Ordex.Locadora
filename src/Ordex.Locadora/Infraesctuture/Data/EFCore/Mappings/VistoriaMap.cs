using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordex.Locadora.Domain.Vistorias;

public class VistoriaMap : IEntityTypeConfiguration<Vistoria>
{
    public void Configure(EntityTypeBuilder<Vistoria> builder)
    {
        builder.HasKey(v => new { v.Codigo, v.CodigoAluguel });

        builder.Property(v => v.SinistroEntrega)
            .IsRequired();

        builder.Property(v => v.CodigoFuncionario)
            .IsRequired();

        builder.Property(v => v.DataRetirada)
            .IsRequired();

        builder.Property(v => v.DataEntrega)
            .IsRequired();

        builder.Property(v => v.TaxaSinistro)
            .IsRequired();

        // Relacionamento com Aluguel
        builder.HasOne(v => v.Aluguel)
            .WithOne()
            .HasForeignKey<Vistoria>(v => v.CodigoAluguel)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Funcionario
        builder.HasOne(v => v.Funcionario)
            .WithMany()
            .HasForeignKey(v => v.CodigoFuncionario)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
