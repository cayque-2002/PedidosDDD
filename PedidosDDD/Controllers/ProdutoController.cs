using Microsoft.AspNetCore.Mvc;
using PedidosDDD.Application.DTOs;
using PedidosDDD.Application.Interfaces;

namespace PedidosDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.ObterTodosAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var produto = await _service.ObterPorIdAsync(id);
        return produto is null ? NotFound() : Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProdutoDto dto)
    {
        await _service.AdicionarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProdutoDto dto)
    {
        await _service.AtualizarAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.RemoverAsync(id);
        return NoContent();
    }
}
