using PedidosDDD.Domain.Entities;
using PedidosDDD.Domain.Interfaces;

namespace PedidosDDD.Infrastructure.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private static readonly List<Pedido> _pedidos = new();

    public Task AdicionarAsync(Pedido pedido)
    {
        _pedidos.Add(pedido);
        return Task.CompletedTask;
    }

    public Task AtualizarAsync(Pedido pedido)
    {
        var index = _pedidos.FindIndex(p => p.Id == pedido.Id);
        if (index != -1)
            _pedidos[index] = pedido;

        return Task.CompletedTask;
    }

    public Task<Pedido?> ObterPorIdAsync(Guid id)
    {
        return Task.FromResult(_pedidos.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Pedido>> ObterTodosAsync()
    {
        return Task.FromResult(_pedidos.AsEnumerable());
    }

    public Task RemoverAsync(Guid id)
    {
        var pedido = _pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido is not null)
            _pedidos.Remove(pedido);

        return Task.CompletedTask;
    }
}
