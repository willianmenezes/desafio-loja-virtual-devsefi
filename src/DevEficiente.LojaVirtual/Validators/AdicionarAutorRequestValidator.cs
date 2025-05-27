using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class AdicionarAutorRequestValidator : AbstractValidator<AdicionarAutorRequest>
{
    public AdicionarAutorRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.Nome)
            .NotEmpty()
            .WithMessage("O nome deve ser preenchido")
            .MaximumLength(100)
            .WithMessage("O nome deve conter menos que 100 caracteres");

        RuleFor(request => request.Email)
            .NotEmpty()
            .WithMessage("O email deve ser preenchido")
            .EmailAddress()
            .WithMessage("E-mail invalido")
            .MaximumLength(100)
            .WithMessage("O e-mail deve conter menos que 100 caracteres")
            .CustomAsync(async (email, validationContext, cancellationToken) =>
            {
                var emailExistente = await context.Autores.AnyAsync(x =>
                    x.Email.ToLower() == email.ToLower(), cancellationToken);

                if (emailExistente)
                    validationContext.AddFailure(new ValidationFailure("E-mail", "E-mail duplicado"));
            });

        RuleFor(request => request.Descricao)
            .NotEmpty()
            .WithMessage("A descricao deve ser preenchida")
            .MaximumLength(400)
            .WithMessage("A descricao deve conter menos que 400 caracteres");
    }
}