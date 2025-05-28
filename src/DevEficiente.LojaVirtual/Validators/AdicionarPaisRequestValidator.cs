using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class AdicionarPaisRequestValidator : AbstractValidator<AdicionarPaisRequest>
{
    public AdicionarPaisRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.Nome)
            .NotEmpty()
            .WithMessage("O nome deve ser informado")
            .MaximumLength(100)
            .WithMessage("O nome deve conter menos que 100 caracteres")
            .CustomAsync(async (nome, validationContext, cancellationToken) =>
            {
                var existePais = await context.Paises.AnyAsync(x =>
                    x.Nome.ToLower() == nome.ToLower(), cancellationToken);

                if (existePais)
                    validationContext.AddFailure(new ValidationFailure("Nome", "Nome duplicado"));
            });
    }
}