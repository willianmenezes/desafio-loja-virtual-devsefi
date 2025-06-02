using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Responses;

public sealed class EstadoResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public static implicit operator EstadoResponse?(Estado? estado)
    {
        if (estado is null)
            return null;

        return new EstadoResponse
        {
            Id = estado.Id,
            Nome = estado.Nome
        };
    }
}