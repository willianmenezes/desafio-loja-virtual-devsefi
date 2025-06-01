using NpgsqlTypes;

namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class ItemPedido
{
    public Guid Id { get; set; }

    public Guid IdPedido { get; set; }

    public Guid IdLivro { get; set; }

    public decimal Valor { get; set; }

    public int Quantidade { get; set; }

    public Pedido? Pedido { get; set; }

    public ItemPedido(Guid idLivro, decimal valor, int quantidade)
    {
        Id = Guid.NewGuid();
        IdLivro = idLivro;
        Quantidade = quantidade;
        Valor = valor;
    }

    public decimal CalcularValorTotal()
    {
        return Valor * Quantidade;
    }
}