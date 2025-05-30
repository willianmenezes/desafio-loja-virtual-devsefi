using DevEficiente.LojaVirtual.Entities.Enums;

namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Pedido
{
    public Guid Id { get; set; }

    public Guid IdCompra { get; set; }

    public StatusPedido StatusPedido { get; set; }

    public IReadOnlyCollection<ItemPedido> Itens => _itens;

    private List<ItemPedido> _itens;

    public Pedido(Guid idCompra)
    {
        Id = Guid.NewGuid();
        IdCompra = idCompra;
        StatusPedido = StatusPedido.Iniciado;
        _itens = [];
    }

    public void AdicionarItens(List<ItemPedido> itens)
    {
        _itens.AddRange(itens);
    }

    private decimal CalcularValorTotal()
    {
        return Itens.Select(x => x.CalcularValorTotal()).Sum();
    }

    public bool ValorTotalValido(decimal totalCalculado)
    {
        return totalCalculado == CalcularValorTotal();
    }
}