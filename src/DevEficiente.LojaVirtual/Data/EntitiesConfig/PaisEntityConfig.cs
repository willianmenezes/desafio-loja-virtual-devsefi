using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class PaisEntityConfig : IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("Paises");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .HasColumnName("Nome")
            .IsUnicode(false)
            .IsRequired();
        
        builder.HasMany(x => x.Estados)
            .WithOne(x => x.Pais)
            .HasForeignKey(x => x.IdPais)
            .HasConstraintName("FK_Estado_Pais_IdPais");
    }
}