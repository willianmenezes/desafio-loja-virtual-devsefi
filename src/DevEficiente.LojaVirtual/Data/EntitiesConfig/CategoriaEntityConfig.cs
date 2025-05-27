using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class CategoriaEntityConfig : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categorias");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .HasColumnName("Nome")
            .IsUnicode(false)
            .IsRequired();
    }
}