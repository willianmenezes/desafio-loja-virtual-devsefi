using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class AdicionarCompraRequest
{
    public Guid IdPais { get; set; }

    public Guid? IdEstado { get; set; }

    public string Email { get; set; }

    public string Nome { get; set; }

    public string SobreNome { get; set; }

    public string Documento { get; set; }

    public string Endereco { get; set; }

    public string Complemento { get; set; }

    public string Cidade { get; set; }

    public string Telefone { get; set; }

    public string Cep { get; set; }

    public string CodigoCupom { get; set; }

    public CriarPedidoRequest Pedido { get; set; }

    public async Task<Compra> ToModel(
        LojaVirtualContext lojaVirtualContext,
        CancellationToken cancellationToken)
    {
        return new Compra(
            IdPais,
            IdEstado,
            Email,
            Nome,
            SobreNome,
            Documento,
            Endereco,
            Complemento,
            Cidade,
            Telefone,
            Cep,
            await Pedido.CriarPedido(lojaVirtualContext, cancellationToken));
    }
}