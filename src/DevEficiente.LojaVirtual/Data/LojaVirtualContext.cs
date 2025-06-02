using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Data;

public class LojaVirtualContext : DbContext
{
    public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
    {
    }

    protected LojaVirtualContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
#if DEBUG
        optionsBuilder.LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
#endif
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LojaVirtualContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Livro> Livros { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Estado> Estados { get; set; }
    public DbSet<Compra> Compras { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedido { get; set; }
    public DbSet<Cupom> Cupons { get; set; }
}