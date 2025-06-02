using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class AdicionarCupomRequestValidator : AbstractValidator<AdicionarCupomRequest>
{
    public AdicionarCupomRequestValidator(LojaVirtualContext lojaVirtualContext)
    {
        RuleFor(x => x.Codigo)
            .NotEmpty()
            .WithMessage("O código do cupom não pode ser vazio.")
            .CustomAsync(async (codigo, context, cancellationToken) =>
            {
                var existeCupom = await lojaVirtualContext.Cupons.AnyAsync(c => c.Codigo == codigo, cancellationToken);

                if (existeCupom)
                    context.AddFailure("Codigo", "Já existe um cupom com este código.");
            });

        RuleFor(x => x.PercentualDesconto)
            .InclusiveBetween(1, 100)
            .WithMessage("O percentual de desconto deve estar entre 1 e 100.");

        RuleFor(x => x.Validade)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("A validade do cupom deve ser uma data futura.");
    }
}