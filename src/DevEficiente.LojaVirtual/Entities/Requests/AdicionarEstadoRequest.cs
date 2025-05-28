using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class AdicionarEstadoRequest
{
    public string Nome { get; set; }

    public Guid IdPais { get; set; }

    public static implicit operator Estado(AdicionarEstadoRequest request)
    {
        return new Estado(request.IdPais, request.Nome);
    }
}