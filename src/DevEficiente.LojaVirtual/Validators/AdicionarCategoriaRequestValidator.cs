using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class AdicionarCategoriaRequestValidator : AbstractValidator<AdicionarCategoriaRequest>
{
    public AdicionarCategoriaRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.Nome)
            .NotEmpty()
            .WithMessage("O nome deve ser preenchido")
            .MaximumLength(100)
            .WithMessage("O nome deve conter menos que 100 caracteres")
            .CustomAsync(async (nome, validationContext, cancellationToken) =>
            {
                var existeTitulo = await context.Categorias.AnyAsync(x =>
                    string.Equals(x.Nome, nome, StringComparison.InvariantCultureIgnoreCase), cancellationToken);

                if (existeTitulo)
                    validationContext.AddFailure(new ValidationFailure("Nome", "Nome duplicado"));
            });
    }
}