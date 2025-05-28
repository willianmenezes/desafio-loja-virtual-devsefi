namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Estado
{
    public Guid Id { get; }

    public Guid IdPais { get; private set; }

    public string Nome { get; private set; }

    public Pais? Pais { get; set; }
    
    public IEnumerable<Compra>? Compras { get; set; }

    public Estado(Guid idPais, string nome)
    {
        Id = Guid.NewGuid();
        IdPais = idPais;
        Nome = nome;
    }
}