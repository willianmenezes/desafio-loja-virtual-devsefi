using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class LivroEntityConfig : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livros");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IdCategoria)
            .HasColumnName("IdCategoria")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.IdAutor)
            .HasColumnName("IdAutor")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.Titulo)
            .HasColumnType("varchar(100)")
            .HasColumnName("Titulo")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Resumo)
            .HasColumnType("varchar(500)")
            .HasColumnName("Resumo")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Sumario)
            .HasColumnType("text")
            .HasColumnName("Sumario")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Preco)
            .HasColumnType("numeric(18,2)")
            .HasColumnName("Preco")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.NumeroPaginas)
            .HasColumnType("integer")
            .HasColumnName("NumeroPaginas")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Isbn)
            .HasColumnType("text")
            .HasColumnName("Isbn")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.DataPublicacao)
            .HasColumnType("date")
            .HasColumnName("DataPublicacao")
            .IsUnicode(false)
            .IsRequired();

        builder.HasOne(x => x.Categoria)
            .WithMany(x => x.Livros)
            .HasForeignKey(x => x.IdCategoria)
            .HasConstraintName("FK_Livro_Categoria_IdCategoria");
        
        builder.HasOne(x => x.Autor)
            .WithMany(x => x.Livros)
            .HasForeignKey(x => x.IdAutor)
            .HasConstraintName("FK_Livro_Autor_IdAutor");
    }
}