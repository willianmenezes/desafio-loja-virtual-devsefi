using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("categorias")]
public class CategoriasController : MainController
{
    private readonly LojaVirtualContext _context;

    public CategoriasController(
        LojaVirtualContext context,
        IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] AdicionarCategoriaRequest request,
        CancellationToken cancellationToken)
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);

        Categoria categoria = request;

        await _context.Categorias.AddAsync(categoria, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(categoria.Id);
    }
}