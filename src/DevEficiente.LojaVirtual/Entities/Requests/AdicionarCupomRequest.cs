using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class AdicionarCupomRequest
{
    public string? Codigo { get; set; }

    public int PercentualDesconto { get; set; }

    public DateTime Validade { get; set; }

    public static implicit operator Cupom(AdicionarCupomRequest request)
    {
        return new Cupom(
            request.Codigo!,
            request.PercentualDesconto,
            request.Validade);
    }
}