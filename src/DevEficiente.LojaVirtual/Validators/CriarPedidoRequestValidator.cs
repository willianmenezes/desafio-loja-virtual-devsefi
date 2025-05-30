using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Requests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Validators;

public sealed class CriarPedidoRequestValidator : AbstractValidator<CriarPedidoRequest>
{
    public CriarPedidoRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.IdCompra)
            .NotEmpty()
            .WithMessage("A compra deve ser informada")
            .CustomAsync(async (idCompra, validationContext, cancellationToken) =>
            {
                var compra = await context.Compras
                    .FirstOrDefaultAsync(x => x.Id == idCompra, cancellationToken);

                if (compra is null)
                    validationContext.AddFailure(new ValidationFailure("IdCompra", "A compra deve ser informada"));
            });

        RuleFor(request => request.Total)
            .NotEmpty()
            .WithMessage("O valor total deve ser informado")
            .GreaterThan(0)
            .WithMessage("O preco deve ser maior que 0");

        RuleFor(request => request.Itens)
            .NotEmpty()
            .WithMessage("Pelo menos um item deve ser adicionado ao pedido");

        RuleForEach(x => x.Itens)
            .SetValidator(new ItemPedidoRequestValidator(context));
    }
}

public sealed class ItemPedidoRequestValidator : AbstractValidator<ItemPedidoRequest>
{
    public ItemPedidoRequestValidator(LojaVirtualContext context)
    {
        RuleFor(request => request.IdLivro)
            .NotEmpty()
            .WithMessage("O livro deve ser informado")
            .CustomAsync(async (idLivro, validationContext, cancellationToken) =>
            {
                var livro = await context.Livros
                    .FirstOrDefaultAsync(x => x.Id == idLivro, cancellationToken);

                if (livro is null)
                    validationContext.AddFailure(new ValidationFailure("IdLivro", "O livro deve ser informado"));
            });


        RuleFor(request => request.Quantidade)
            .NotEmpty()
            .WithMessage("A quantidade deve ser informada")
            .GreaterThan(0)
            .WithMessage("A quantidade deve ser maior que 0");
    }
}