using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class AutorEntityConfig : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("Autores");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .HasColumnName("Nome")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Email)
            .HasColumnType("varchar(100)")
            .HasColumnName("Email")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Descricao)
            .HasColumnType("varchar(400)")
            .HasColumnName("Descricao")
            .IsUnicode(false)
            .IsRequired();
    }
}