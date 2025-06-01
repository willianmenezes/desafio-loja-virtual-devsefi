using System.Text.Json.Serialization;
using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class CriarPedidoRequest
{
    public decimal Total { get; set; }

    public IEnumerable<ItemPedidoRequest>? Itens { get; set; }

    public async Task<Func<Compra, Pedido>> CriarPedido(
        LojaVirtualContext context,
        CancellationToken cancellationToken)
    {
        var idsLivros = Itens!.Select(x => x.IdLivro);

        var livros = await context.Livros
            .Where(x => idsLivros.Contains(x.Id))
            .ToListAsync(cancellationToken);

        return compra =>
        {
            var pedido = new Pedido(compra.Id, Itens!.Select(x => new ItemPedido(
                x.IdLivro,
                livros.First(y => y.Id == x.IdLivro).Preco,
                x.Quantidade
            )).ToList());

            return pedido;
        };
    }
}

public sealed class ItemPedidoRequest
{
    public Guid IdLivro { get; set; }

    public int Quantidade { get; set; }
}