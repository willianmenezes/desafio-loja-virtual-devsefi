namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Pais
{
    public Guid Id { get; }

    public string Nome { get; private set; }

    public IEnumerable<Estado>? Estados { get; set; }
    
    public Pais(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }
}