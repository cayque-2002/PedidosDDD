using PedidosDDD.Application.DTOs;
using PedidosDDD.Application.Interfaces;
using PedidosDDD.Domain.Entities;
using PedidosDDD.Domain.Interfaces;

namespace PedidosDDD.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _repo;

    public PedidoService(IPedidoRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<PedidoDto>> ObterTodosAsync()
    {
        var pedidos = await _repo.ObterTodosAsync();
        return pedidos.Select(p => new PedidoDto
        {
            Id = p.Id,
            DataCriacao = p.DataCriacao,
            Status = p.Status.ToString(),
            Itens = p.Itens.Select(i => new ItemPedidoDto
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
                ValorUnitario = i.ValorUnitario
            }).ToList()
        });
    }

    public async Task<PedidoDto?> ObterPorIdAsync(long id)
    {
        var pedido = await _repo.ObterPorIdAsync(id);
        if (pedido is null) return null;

        return new PedidoDto
        {
            Id = pedido.Id,
            DataCriacao = pedido.DataCriacao,
            Status = pedido.Status.ToString(),
            Itens = pedido.Itens.Select(i => new ItemPedidoDto
            {
                ProdutoId = i.ProdutoId,
                Quantidade = i.Quantidade,
                ValorUnitario = i.ValorUnitario
            }).ToList()
        };
    }

    public async Task<long> CriarAsync(List<ItemPedidoDto> itensDto)
    {
        var pedido = new Pedido();

        foreach (var item in itensDto)
        {
            var novoItem = new ItemPedido(item.ProdutoId, item.Quantidade, item.ValorUnitario);
            pedido.AdicionarItem(novoItem);
        }

        await _repo.AdicionarAsync(pedido);
        return pedido.Id;
    }

    public async Task FinalizarAsync(long id)
    {
        var pedido = await _repo.ObterPorIdAsync(id);
        if (pedido is null) throw new Exception("Pedido não encontrado");

        pedido.Finalizar();
        await _repo.AtualizarAsync(pedido);
    }

    public async Task CancelarAsync(long id)
    {
        var pedido = await _repo.ObterPorIdAsync(id);
        if (pedido is null) throw new Exception("Pedido não encontrado");

        pedido.Cancelar();
        await _repo.AtualizarAsync(pedido);
    }
}
