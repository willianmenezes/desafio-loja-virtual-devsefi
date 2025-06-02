using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class CupomEntityConfig : IEntityTypeConfiguration<Cupom>
{
    public void Configure(EntityTypeBuilder<Cupom> builder)
    {
        builder.ToTable("Cupons");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Codigo)
            .HasColumnName("Codigo")
            .HasColumnType("varchar(50)")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.PercentualDesconto)
            .HasColumnName("PercentualDesconto")
            .HasColumnType("integer")
            .IsRequired();

        builder.Property(c => c.Validade)
            .HasColumnName("Validade")
            .HasColumnType("date")
            .IsRequired();
    }
}