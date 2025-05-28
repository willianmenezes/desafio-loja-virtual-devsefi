using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("paises")]
public sealed class PaisesController : MainController
{
    private readonly LojaVirtualContext _context;
    
    public PaisesController(
        IServiceProvider serviceProvider,
        LojaVirtualContext context) : base(serviceProvider)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] AdicionarPaisRequest request,
        CancellationToken cancellationToken)
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);

        Pais pais = request;

        await _context.Paises.AddAsync(pais, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(pais.Id);
    }
}