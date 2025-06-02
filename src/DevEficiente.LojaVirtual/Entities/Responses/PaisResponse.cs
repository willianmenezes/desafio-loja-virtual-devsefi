using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Responses;

public sealed class PaisResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public static implicit operator PaisResponse(Pais pais)
    {
        return new PaisResponse
        {
            Id = pais.Id,
            Nome = pais.Nome
        };
    }
}