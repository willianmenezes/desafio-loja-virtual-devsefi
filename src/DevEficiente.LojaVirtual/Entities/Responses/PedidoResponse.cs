using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Responses;

public sealed class PedidoResponse
{
    
    public Guid Id { get; set; }

    public string Status { get; set; }

    public decimal ValorTotal { get; set; }
    
    public static implicit operator PedidoResponse(Pedido pedido)
    {
        return new PedidoResponse
        {
            Id = pedido.Id,
            Status = pedido.StatusPedido.ToString(),
            ValorTotal = pedido.CalcularValorTotal(),
        };
    }
}