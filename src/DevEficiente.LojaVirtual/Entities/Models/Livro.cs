namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Livro
{
    public Guid Id { get; set; }

    public Guid IdCategoria { get; private set; }

    public Guid IdAutor { get; private set; }

    public string Titulo { get; private set; }

    public string Resumo { get; private set; }
    
    public string Sumario { get; private set; }

    public decimal Preco { get; private set; }

    public int NumeroPaginas { get; private set; }

    public string Isbn { get; private set; }

    public DateTime DataPublicacao { get; private set; }

    public Categoria Categoria { get; set; }

    public Autor Autor { get; set; }

    public Livro(
        Guid idCategoria,
        Guid idAutor,
        string titulo,
        string resumo,
        string sumario,
        decimal preco,
        int numeroPaginas,
        string isbn,
        DateTime dataPublicacao)
    {
        Id = Guid.NewGuid();
        IdCategoria = idCategoria;
        IdAutor = idAutor;
        Titulo = titulo;
        Resumo = resumo;
        Sumario = sumario;
        Preco = preco;
        NumeroPaginas = numeroPaginas;
        Isbn = isbn;
        DataPublicacao = dataPublicacao;
    }
}