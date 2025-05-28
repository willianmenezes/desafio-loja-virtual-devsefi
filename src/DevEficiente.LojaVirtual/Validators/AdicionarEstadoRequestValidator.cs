using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class AdicionarEstadoRequestValidator: AbstractValidator<AdicionarEstadoRequest>
{
    public AdicionarEstadoRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.IdPais)
            .NotEmpty()
            .WithMessage("O pais deve ser informado");
        
        RuleFor(request => request.Nome)
            .NotEmpty()
            .WithMessage("O nome deve ser informado")
            .MaximumLength(100)
            .WithMessage("O nome deve conter menos que 100 caracteres")
            .CustomAsync(async (nome, validationContext, cancellationToken) =>
            {
                var existeEstado = await context.Estados.AnyAsync(x =>
                    x.Nome.ToLower() == nome.ToLower(), cancellationToken);

                if (existeEstado)
                    validationContext.AddFailure(new ValidationFailure("Nome", "Nome duplicado"));
            });
    }
}