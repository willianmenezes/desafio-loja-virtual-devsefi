using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Data;

public class LojaVirtualContext : DbContext
{
    public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
}