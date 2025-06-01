using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEficiente.LojaVirtual.Data.EntitiesConfig;

public sealed class PedidoEntityConfig : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");

        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.IdCompra)
            .HasColumnName("IdCompra")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.StatusPedido)
            .HasColumnName("StatusPedido")
            .IsRequired();
        
        builder.HasMany(x => x.Itens)
            .WithOne(x => x.Pedido)
            .HasForeignKey(x => x.IdPedido)
            .HasConstraintName("FK_Pedido_ItemPedido_IdPedido");
    }
}