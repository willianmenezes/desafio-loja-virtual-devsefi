using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly IServiceProvider _serviceProvider;

    protected MainController(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected async Task<(string erro, bool contemErros)> ValidarErrosAsync<TRequest>(
        TRequest request, CancellationToken cancellationToken)
        where TRequest : class
    {
        var validator = _serviceProvider.GetService<IValidator<TRequest>>();

        if (validator is null)
            return ("Nao foi possivel validar as informacoes", true);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return (validationResult.Errors.First().ErrorMessage, true);
        }

        return (string.Empty, false);
    }
}