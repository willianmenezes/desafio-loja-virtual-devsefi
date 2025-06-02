using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Responses;

public sealed class ObterCompraPorIdResponse
{
    public Guid Id { get; set; }

    public PaisResponse Pais { get; set; }

    public EstadoResponse? Estado { get; set; }

    public PedidoResponse Pedido { get; set; }

    public string Email { get; set; }

    public string Nome { get; set; }

    public string SobreNome { get; set; }

    public string Documento { get; set; }

    public string Endereco { get; set; }

    public string Complemento { get; set; }

    public string Cidade { get; set; }

    public string Telefone { get; set; }

    public string Cep { get; set; }

    public bool PossuiCupom { get; set; }

    public decimal ValorTotal { get; set; }

    public decimal ValorTotalComDesconto { get; set; }

    public static implicit operator ObterCompraPorIdResponse(Compra compra)
    {
        var compraResponse = new ObterCompraPorIdResponse()
        {
            Id = compra.Id,
            Email = compra.Email,
            Nome = compra.Nome,
            SobreNome = compra.SobreNome,
            Documento = compra.Documento,
            Endereco = compra.Endereco,
            Complemento = compra.Complemento,
            Cidade = compra.Cidade,
            Telefone = compra.Telefone,
            Cep = compra.Cep,
            Pais = compra.Pais!,
            Estado = compra.Estado,
            Pedido = compra.Pedido!
        };

        compraResponse.PossuiCupom = compra.IdCupom.HasValue;
        compraResponse.ValorTotal = compra.Pedido!.CalcularValorTotal();
        compraResponse.ValorTotalComDesconto = compra.ObterValorTotalComDescontoCupom();

        return compraResponse;
    }
}