using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed record AdicionarAutorRequest
{
    public string Nome { get; set; }

    public string Email { get; set; }

    public string Descricao { get; set; }

    public static implicit operator Autor(AdicionarAutorRequest adicionarAutor) =>
        new(adicionarAutor.Nome, adicionarAutor.Email, adicionarAutor.Descricao);
}