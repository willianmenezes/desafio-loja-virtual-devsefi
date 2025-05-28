using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class AdicionarCategoriaRequest
{
    public string Nome { get; set; }
    
    public static implicit operator Categoria(AdicionarCategoriaRequest adicionarAutor) =>
        new(adicionarAutor.Nome);
}

