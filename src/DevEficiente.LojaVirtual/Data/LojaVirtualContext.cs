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

    public DbSet<Autor> Autores { get; set; }
}