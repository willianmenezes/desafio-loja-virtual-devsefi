using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("cupons")]
public class CuponsController : MainController
{
    private readonly LojaVirtualContext _lojaVirtualContext;


    public CuponsController(
        IServiceProvider serviceProvider,
        LojaVirtualContext lojaVirtualContext) : base(serviceProvider)
    {
        _lojaVirtualContext = lojaVirtualContext;
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] AdicionarCupomRequest request,
        CancellationToken cancellationToken
    )
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);

        Cupom cupom = request;
        
        await _lojaVirtualContext.Cupons.AddAsync(cupom, cancellationToken);
        await _lojaVirtualContext.SaveChangesAsync(cancellationToken);

        return Ok(cupom.Id);
    }
}