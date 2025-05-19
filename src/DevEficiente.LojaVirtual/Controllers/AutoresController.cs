using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Controllers;

[ApiController]
[Route("autores")]
public class AutoresController : ControllerBase
{
    private readonly LojaVirtualContext _context;

    public AutoresController(LojaVirtualContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> RegistrarAutores(
        [FromBody] AutorRequest autorRequest,
        CancellationToken cancellationToken)
    {
        Autor autor = autorRequest;
        
        var emailExistente = await _context.Autores.AnyAsync(x =>
            string.Equals(x.Email, autor.Email, StringComparison.CurrentCultureIgnoreCase), cancellationToken);
        
        if (emailExistente)
            return BadRequest("Email invalido");

        await _context.AddAsync(autor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(autor.Id);
    }
}