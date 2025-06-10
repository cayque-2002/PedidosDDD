using PedidosDDD.Domain.Entities;
using PedidosDDD.Domain.Interfaces;

namespace PedidosDDD.Infrastructure.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private static readonly List<Produto> _produtos = new();

    public Task AdicionarAsync(Produto produto)
    {
        _produtos.Add(produto);
        return Task.CompletedTask;
    }

    public Task AtualizarAsync(Produto produto)
    {
        var index = _produtos.FindIndex(p => p.Id == produto.Id);
        if (index != -1)
            _produtos[index] = produto;

        return Task.CompletedTask;
    }

    public Task<Produto?> ObterPorIdAsync(long id)
    {
        return Task.FromResult(_produtos.FirstOrDefault(p => p.Id == id));
    }

    public Task<IEnumerable<Produto>> ObterTodosAsync()
    {
        return Task.FromResult(_produtos.AsEnumerable());
    }

    public Task RemoverAsync(long id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);
        if (produto is not null)
            _produtos.Remove(produto);

        return Task.CompletedTask;
    }
}
