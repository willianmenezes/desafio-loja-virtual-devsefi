using DevEficiente.LojaVirtual.Entities.Enums;

namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Pedido
{
    public Guid Id { get; set; }

    public Guid IdCompra { get; set; }

    public StatusPedido StatusPedido { get; set; }

    public Compra? Compra { get; set; }

    public IReadOnlyCollection<ItemPedido> Itens => _itens;

    private List<ItemPedido> _itens = [];

    public Pedido(Guid idCompra, List<ItemPedido> itens)
    {
        Id = Guid.NewGuid();
        IdCompra = idCompra;
        StatusPedido = StatusPedido.Iniciado;
        _itens.AddRange(itens);
    }

    [Obsolete("Para uso do EF Core apenas", true)]
    public Pedido()
    {
        
    }

    public decimal CalcularValorTotal()
    {
        return Itens.Select(x => x.CalcularValorTotal()).Sum();
    }

    public bool ValorTotalValido(decimal totalCalculado)
    {
        return totalCalculado == CalcularValorTotal();
    }
}