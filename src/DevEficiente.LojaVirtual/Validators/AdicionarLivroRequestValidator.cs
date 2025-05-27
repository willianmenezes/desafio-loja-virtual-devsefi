using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class AdicionarLivroRequestValidator : AbstractValidator<AdicionarLivroRequest>
{
    public AdicionarLivroRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.IdCategoria)
            .NotEmpty()
            .WithMessage("A categoria deve ser informada");

        RuleFor(request => request.IdAutor)
            .NotEmpty()
            .WithMessage("O autor deve ser informado");

        RuleFor(request => request.Titulo)
            .NotEmpty()
            .WithMessage("O titulo deve ser informado")
            .MaximumLength(100)
            .WithMessage("O titulo deve conter menos que 100 caracteres")
            .CustomAsync(async (titulo, validationContext, cancellationToken) =>
            {
                var existeTitulo = await context.Livros.AnyAsync(x =>
                    x.Titulo.ToLower() == titulo.ToLower(), cancellationToken);

                if (existeTitulo)
                    validationContext.AddFailure(new ValidationFailure("Titulo", "Titulo duplicado"));
            });

        RuleFor(request => request.Resumo)
            .NotEmpty()
            .WithMessage("O autor deve ser informado")
            .MaximumLength(500)
            .WithMessage("O resumo deve conter menos que 500 caracteres");

        RuleFor(request => request.Sumario)
            .NotEmpty()
            .WithMessage("O sumario deve ser informado");

        RuleFor(request => request.Preco)
            .NotEmpty()
            .WithMessage("O preco deve ser informado")
            .GreaterThanOrEqualTo(20)
            .WithMessage("O preco deve ser no minimo 20");

        RuleFor(request => request.NumeroPaginas)
            .NotEmpty()
            .WithMessage("O numero de paginas deve ser informado")
            .GreaterThanOrEqualTo(100)
            .WithMessage("O numero de paginas deve ser no minimo 100");

        RuleFor(request => request.Isbn)
            .NotEmpty()
            .WithMessage("O ISBN deve ser informado");

        RuleFor(request => request.DataPublicacao)
            .NotEmpty()
            .WithMessage("A data de publicacao deve ser informada")
            .GreaterThan(DateTime.Now)
            .WithMessage("A data deve ser no futuro");
    }
}