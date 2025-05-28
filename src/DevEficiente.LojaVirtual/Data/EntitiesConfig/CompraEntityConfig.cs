using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class CompraEntityConfig : IEntityTypeConfiguration<Compra>
{
    public void Configure(EntityTypeBuilder<Compra> builder)
    {
        builder.ToTable("Paises");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.IdPais)
            .HasColumnName("IdPais")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.IdEstado)
            .HasColumnName("IdEstado")
            .HasColumnType("uuid")
            .IsRequired(false);
        
        builder.Property(x => x.Email)
            .HasColumnType("varchar(100)")
            .HasColumnName("Email")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Nome)
            .HasColumnType("varchar(100)")
            .HasColumnName("Nome")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.SobreNome)
            .HasColumnType("varchar(100)")
            .HasColumnName("SobreNome")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Documento)
            .HasColumnType("varchar(14)")
            .HasColumnName("Documento")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Endereco)
            .HasColumnType("varchar(250)")
            .HasColumnName("Endereco")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Complemento)
            .HasColumnType("varchar(250)")
            .HasColumnName("Complemento")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Cidade)
            .HasColumnType("varchar(100)")
            .HasColumnName("Cidade")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Telefone)
            .HasColumnType("varchar(11)")
            .HasColumnName("Telefone")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Cep)
            .HasColumnType("varchar(8)")
            .HasColumnName("Cep")
            .IsUnicode(false)
            .IsRequired();
        
        builder.HasOne(x => x.Pais)
            .WithMany(x => x.Compras)
            .HasForeignKey(x => x.IdPais)
            .HasConstraintName("FK_Compra_Pais_IdPais");
        
        builder.HasOne(x => x.Estado)
            .WithMany(x => x.Compras)
            .HasForeignKey(x => x.IdPais)
            .HasConstraintName("FK_Compra_Estado_IdEstado");
    }
}