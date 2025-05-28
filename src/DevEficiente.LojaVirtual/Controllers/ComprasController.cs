using System.Runtime.CompilerServices;
using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("compras")]
public class ComprasController : MainController
{
    private readonly LojaVirtualContext _context;
    
    public ComprasController(
        LojaVirtualContext context,
        IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] AdicionarCompraRequest request,
        CancellationToken cancellationToken)
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);

        Compra compra = request;

        await _context.Compras.AddAsync(compra, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(compra.Id);
    }
}