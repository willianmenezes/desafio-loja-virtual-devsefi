using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Requests;

public sealed record AutorRequest
{
    [Required(AllowEmptyStrings = false)]
    [JsonPropertyName("nome")]
    public required string Nome { get; set; }

    [Required(AllowEmptyStrings = false)]
    [EmailAddress]
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [Required]
    [MaxLength(400)]
    [JsonPropertyName("descricao")]
    public required string Descricao { get; set; }

    public static implicit operator Autor(AutorRequest autor) =>
        new(autor.Nome, autor.Email, autor.Descricao);
}