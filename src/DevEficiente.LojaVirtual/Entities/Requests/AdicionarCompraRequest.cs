using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class AdicionarCompraRequest
{
    public Guid Id { get; }

    public Guid IdPais { get; set; }

    public Guid IdEstado { get; set; }

    public string Email { get; set; }

    public string Nome { get; set; }

    public string SobreNome { get; set; }

    public string Documento { get; set; }

    public string Endereco { get; set; }

    public string Complemento { get; set; }

    public string Cidade { get; set; }

    public string Telefone { get; set; }

    public string Cep { get; set; }

    public static implicit operator Compra(AdicionarCompraRequest request)
    {
        return new Compra(
            request.IdPais,
            request.IdEstado,
            request.Email,
            request.Nome,
            request.SobreNome,
            request.Documento,
            request.Endereco,
            request.Complemento,
            request.Cidade,
            request.Telefone,
            request.Cep);
    }
}