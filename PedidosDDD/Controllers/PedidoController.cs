using Microsoft.AspNetCore.Mvc;
using PedidosDDD.Application.DTOs;
using PedidosDDD.Application.Interfaces;

namespace PedidosDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _service;

    public PedidoController(IPedidoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.ObterTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var pedido = await _service.ObterPorIdAsync(id);
        return pedido is null ? NotFound() : Ok(pedido);
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] List<ItemPedidoDto> itens)
    {
        var id = await _service.CriarAsync(itens);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    [HttpPut("finalizar/{id}")]
    public async Task<IActionResult> Finalizar(long id)
    {
        await _service.FinalizarAsync(id);
        return NoContent();
    }

    [HttpPut("cancelar/{id}")]
    public async Task<IActionResult> Cancelar(long id)
    {
        await _service.CancelarAsync(id);
        return NoContent();
    }
}
