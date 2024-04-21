using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordex.Locadora.Domain.Vistorias;

public class VistoriaObservacaoMap : IEntityTypeConfiguration<VistoriaObservacao>
{
    public void Configure(EntityTypeBuilder<VistoriaObservacao> builder)
    {
        builder.HasKey(v => new { v.Codigo, v.CodigoVistoria, v.CodigoAluguel });

        // Relacionamento com Aluguel
        builder.HasOne(v => v.Aluguel)
            .WithOne()
            .HasForeignKey<VistoriaObservacao>(v => v.CodigoAluguel)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        // Relacionamento com Vistoria
        builder.HasOne(v => v.Vistoria)
            .WithOne()
            .HasForeignKey<VistoriaObservacao>(v => v.CodigoVistoria)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


    }
}
