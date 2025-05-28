using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class AdicionarPaisRequest
{
    public string Nome { get; set; }

    public static implicit operator Pais(AdicionarPaisRequest request)
    {
        return new Pais(request.Nome);
    }
}