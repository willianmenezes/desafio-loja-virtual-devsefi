using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("autores")]
public class AutoresController : MainController
{
    private readonly LojaVirtualContext _context;

    public AutoresController( LojaVirtualContext context,
        IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] AdicionarAutorRequest request,
        CancellationToken cancellationToken)
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);
        
        Autor autor = request;

        await _context.Autores.AddAsync(autor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(autor.Id);
    }
}