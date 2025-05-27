namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Categoria
{
    public Guid Id { get; private set; }

    public string Nome { get; private set; }

    public Categoria(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }
}