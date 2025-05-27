using System.Text.Json.Serialization;
using DevEficiente.LojaVirtual.Entities.Models;

namespace DevEficiente.LojaVirtual.Entities.Responses;

public sealed class ObterLivroPorIdResponse
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    [JsonPropertyName("id_categoria")]
    public Guid IdCategoria { get; set; }

    [JsonPropertyName("id_autor")]
    public Guid IdAutor { get; set; }

    [JsonPropertyName("titulo")]
    public string? Titulo { get; set; }

    [JsonPropertyName("resumo")]
    public string? Resumo { get; set; }
    
    [JsonPropertyName("sumario")]
    public string? Sumario { get; set; }

    [JsonPropertyName("preco")]
    public decimal Preco { get; set; }

    [JsonPropertyName("numero_paginas")]
    public int NumeroPaginas { get; set; }

    [JsonPropertyName("isbn")]
    public string? Isbn { get; set; }

    [JsonPropertyName("data_publicacao")]
    public DateTime DataPublicacao { get; set; }

    public static implicit operator ObterLivroPorIdResponse(Livro livro)
    {
        return new ()
        {
            DataPublicacao = livro.DataPublicacao,
            Id = livro.Id,
            IdAutor = livro.IdAutor,
            IdCategoria = livro.IdCategoria,
            Isbn = livro.Isbn,
            NumeroPaginas = livro.NumeroPaginas,
            Preco = livro.Preco,
            Resumo = livro.Resumo,
            Sumario = livro.Sumario,
            Titulo = livro.Titulo
        };
    }
}