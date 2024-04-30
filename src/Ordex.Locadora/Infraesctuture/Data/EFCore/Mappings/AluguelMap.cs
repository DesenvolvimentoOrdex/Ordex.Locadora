using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordex.Locadora.Domain.Alugueis;

public class AluguelMap : IEntityTypeConfiguration<Aluguel>
{
    public void Configure(EntityTypeBuilder<Aluguel> builder)
    {
        builder.HasKey(a => a.Codigo);

        builder.Property(a => a.Valor)
            .IsRequired();

        builder.Property(a => a.PossuiDesconto)
            .IsRequired();

        builder.Property(a => a.PercentualDesconto)
            .IsRequired();

        builder.Property(a => a.Status)
            .IsRequired();

        // Relacionamento com Cliente
        builder.HasOne(a => a.Cliente)
            .WithMany()
            .HasForeignKey(a => a.CodigoCliente)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Funcionario
        builder.HasOne(a => a.Funcionario)
            .WithMany()
            .HasForeignKey(a => a.CodigoFuncionario)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Relacionamento com Veiculo
        builder.HasOne(a => a.Veiculo)
            .WithMany()
            .HasForeignKey(a => a.PlacaVeiculo)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}