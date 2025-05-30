using System.Text.Json.Serialization;
using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class CriarPedidoRequest
{
    [JsonPropertyName("id_compra")] public Guid IdCompra { get; set; }

    [JsonPropertyName("total")] public decimal Total { get; set; }

    [JsonPropertyName("itens")] public IEnumerable<ItemPedidoRequest>? Itens { get; set; }

    public async Task<Pedido> CriarPedido(LojaVirtualContext context, CancellationToken cancellationToken)
    {
        var idsLivros = Itens!.Select(x => x.IdLivro);

        var livros = await context.Livros
            .Where(x => idsLivros!.Contains(x.Id))
            .ToListAsync(cancellationToken);

        var pedido = new Pedido(IdCompra);

        pedido.AdicionarItens(Itens!.Select(x => new ItemPedido(
            pedido.Id,
            x.IdLivro,
            livros.First(y => y.Id == x.IdLivro).Preco,
            x.Quantidade
        )).ToList());

        return pedido;
    }
}

public sealed class ItemPedidoRequest
{
    [JsonPropertyName("id_livro")] public Guid IdLivro { get; set; }

    [JsonPropertyName("quantidade")] public int Quantidade { get; set; }
}