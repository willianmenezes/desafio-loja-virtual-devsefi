namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Autor
{
    public Guid Id { get; }

    public string Nome { get; private set; }

    public string Email { get; private set; }

    public string Descricao { get; private set; }

    public DateTime Cadastro { get; private set; }

    public IEnumerable<Livro>? Livros { get; set; }

    public Autor(string nome, string email, string descricao)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Descricao = descricao;
        Cadastro = DateTime.UtcNow;
    }
}