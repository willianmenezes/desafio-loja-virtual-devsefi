using DevEficiente.LojaVirtual.Data;
using DevEficiente.LojaVirtual.Entities.Models;
using DevEficiente.LojaVirtual.Entities.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DevEficiente.LojaVirtual.Controllers;

[Route("pedidos")]
public sealed class PedidosController : MainController
{
    private readonly LojaVirtualContext _context;

    public PedidosController(
        IServiceProvider serviceProvider,
        LojaVirtualContext context) : base(
        serviceProvider)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> Registrar(
        [FromBody] CriarPedidoRequest request,
        CancellationToken cancellationToken)
    {
        var validarErrorResult = await ValidarErrosAsync(request, cancellationToken);

        if (validarErrorResult.contemErros)
            return BadRequest(validarErrorResult.erro);

        var pedido = await request.CriarPedido(_context, cancellationToken);

        if (!pedido.ValorTotalValido(request.Total))
            return BadRequest("Valor total invalido");
        
        await _context.Pedidos.AddAsync(pedido, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Ok(pedido.Id);
    }
}