using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class EstadoEntityConfig : IEntityTypeConfiguration<Estado>
{
    public void Configure(EntityTypeBuilder<Estado> builder)
    {
        builder.ToTable("Estados");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.IdPais)
            .HasColumnName("IdPais")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .HasColumnName("Nome")
            .IsUnicode(false)
            .IsRequired();
    }
}