using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DevEficiente.LojaVirtual.Entities.Models;

public sealed class Autor
{
    [Key]
    public int Id { get; private set; }
    
    [Required]
    [MaxLength(100)]
    public string Nome { get; private set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; private set; }

    [Required]
    [MaxLength(400)]
    public string Descricao { get; private set; }

    [Required]
    public DateTime Cadastro { get; private set; }

    public Autor(string nome, string email, string descricao)
    {
        Nome = nome;
        Email = email;
        Descricao = descricao;
        Cadastro = DateTime.UtcNow;
    }
}