using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class ItemPedidoEntityConfig : IEntityTypeConfiguration<ItemPedido>
{
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
        builder.ToTable("ItensPedido");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.IdPedido)
            .HasColumnName("IdPedido")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.IdLivro)
            .HasColumnName("IdLivro")
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(x => x.Valor)
            .HasColumnType("numeric(18,2)")
            .HasColumnName("Valor")
            .IsUnicode(false)
            .IsRequired();
        
        builder.Property(x => x.Quantidade)
            .HasColumnType("integer")
            .HasColumnName("Quantidade")
            .IsUnicode(false)
            .IsRequired();
    }
}