using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using DevEficiente.LojaVirtual.Entities.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        var compra = await request.ToModel(_context, cancellationToken);

        if (!string.IsNullOrWhiteSpace(request.CodigoCupom))
        {
            var cupom = await _context.Cupons
                .FirstOrDefaultAsync(x => x.Codigo == request.CodigoCupom, cancellationToken);

            var cupomAplicaco = new CupomAplicado(
                cupom!.Id,
                cupom.Codigo,
                cupom.PercentualDesconto,
                cupom.Validade
            );

           compra.AdicionarCupomDesconto(cupomAplicaco);
        }

        await _context.Compras.AddAsync(compra, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(compra.Id);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(Guid id, CancellationToken cancellationToken)
    {
        var compra = await _context.Compras
            .AsNoTracking()
            .Include(x => x.Pais)
            .Include(x => x.Estado)
            .Include(x => x.Pedido)
            .ThenInclude(x => x.Itens)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (compra is null)
            return NotFound();

        ObterCompraPorIdResponse compraResponse = compra;
        
        return Ok(compraResponse);
    }
}