using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed class AdicionarLivroRequest
{
    public Guid IdCategoria { get; set; }

    public Guid IdAutor { get; set; }

    public string Titulo { get; set; }

    public string Resumo { get; set; }

    public string Sumario { get; set; }

    public decimal Preco { get; set; }

    public int NumeroPaginas { get; set; }

    public string Isbn { get; set; }

    public DateTime DataPublicacao { get; set; }

    public static implicit operator Livro(AdicionarLivroRequest request)
    {
        return new Livro(
            request.IdCategoria,
            request.IdAutor,
            request.Titulo,
            request.Resumo,
            request.Sumario,
            request.Preco,
            request.NumeroPaginas,
            request.Isbn,
            request.DataPublicacao
        );
    }
}