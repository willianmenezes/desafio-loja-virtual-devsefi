using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("livros")]
public class LivrosController : MainController
{
    private readonly LojaVirtualContext _context;

    public LivrosController(
        LojaVirtualContext context,
        IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] AdicionarLivroRequest request,
        CancellationToken cancellationToken)
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);

        Livro livro = request;

        await _context.Livros.AddAsync(livro, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(livro.Id);
    }
}