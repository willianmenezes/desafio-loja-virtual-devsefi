using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class AdicionarCompraRequestValidator : AbstractValidator<AdicionarCompraRequest>
{
    public AdicionarCompraRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.IdPais)
            .NotEmpty()
            .WithMessage("O pais deve ser informado");

        RuleFor(request => request.IdEstado)
            .CustomAsync(async (id, validationContext, cancellationToken) =>
            {
                var idPais = validationContext.InstanceToValidate.IdPais;

                var pais = await context.Paises
                    .Include(x => x.Estados)
                    .FirstOrDefaultAsync(x => x.Id == idPais, cancellationToken);

                if (!pais?.Estados?.Any() ?? true)
                    return;

                if (!pais.Estados.Any(x => x.Id == id))
                    validationContext.AddFailure(new ValidationFailure("Estado", "O estado precisa ser informado"));
            });

        RuleFor(request => request.Email)
            .NotEmpty()
            .WithMessage("O email deve ser preenchido")
            .EmailAddress()
            .WithMessage("E-mail invalido")
            .MaximumLength(100)
            .WithMessage("O e-mail deve conter menos que 100 caracteres");

        RuleFor(request => request.Nome)
            .NotEmpty()
            .WithMessage("O nome deve ser preenchido")
            .MaximumLength(100)
            .WithMessage("O nome deve conter menos que 100 caracteres");

        RuleFor(request => request.SobreNome)
            .NotEmpty()
            .WithMessage("O sobrenome deve ser preenchido")
            .MaximumLength(100)
            .WithMessage("O sobrenome deve conter menos que 100 caracteres");

        RuleFor(request => request.Documento)
            .NotEmpty()
            .WithMessage("O documento deve ser preenchido")
            .Length(11, 14)
            .WithMessage("O documento deve conter entre 11 e 14 caracteres caracteres (CPF ou CNPJ)");

        RuleFor(request => request.Endereco)
            .NotEmpty()
            .WithMessage("O endereco deve ser preenchido")
            .MaximumLength(250)
            .WithMessage("O endereco deve conter menos que 100 caracteres");

        RuleFor(request => request.Complemento)
            .NotEmpty()
            .WithMessage("O complemento deve ser preenchido")
            .MaximumLength(250)
            .WithMessage("O complemento deve conter menos que 100 caracteres");

        RuleFor(request => request.Cidade)
            .NotEmpty()
            .WithMessage("A cidade deve ser preenchido")
            .MaximumLength(100)
            .WithMessage("A cidade deve conter menos que 100 caracteres");

        RuleFor(request => request.Telefone)
            .NotEmpty()
            .WithMessage("O telefone deve ser informado")
            .MaximumLength(11)
            .WithMessage("O telefone deve ter no maximo 11 caracteres");

        RuleFor(request => request.Cep)
            .NotEmpty()
            .WithMessage("O cep deve ser informado")
            .Length(8)
            .WithMessage("O cep deve ter 8 caracteres");
    }
}