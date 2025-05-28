using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("estados")]
public sealed class EstadosController : MainController
{
    private readonly LojaVirtualContext _context;
    
    public EstadosController(IServiceProvider serviceProvider, LojaVirtualContext context) : base(serviceProvider)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] AdicionarEstadoRequest request,
        CancellationToken cancellationToken)
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);

        Estado estado = request;

        await _context.Estados.AddAsync(estado, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(estado.Id);
    }
}