using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> RegistrarAutores([FromBody] AutorRequest autorRequest)
    {
        Autor autor = autorRequest;
        await _context.AddAsync(autor);
        return Ok(autor.Id);
    }
}