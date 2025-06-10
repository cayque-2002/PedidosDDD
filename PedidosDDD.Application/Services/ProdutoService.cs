using PedidosDDD.Application.DTOs;
using PedidosDDD.Application.Interfaces;
using PedidosDDD.Domain.Entities;
using PedidosDDD.Domain.Interfaces;

namespace PedidosDDD.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _repo;

    public ProdutoService(IProdutoRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<ProdutoDto>> ObterTodosAsync()
    {
        var produtos = await _repo.ObterTodosAsync();
        return produtos.Select(p => new ProdutoDto
        {
            Id = p.Id,
            Nome = p.Nome,
            Preco = p.Preco
        });
    }

    public async Task<ProdutoDto?> ObterPorIdAsync(long id)
    {
        var produto = await _repo.ObterPorIdAsync(id);
        return produto is null ? null : new ProdutoDto
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Preco = produto.Preco
        };
    }

    public async Task AdicionarAsync(ProdutoDto dto)
    {
        var produto = new Produto(dto.Nome, dto.Preco);
        await _repo.AdicionarAsync(produto);
    }

    public async Task AtualizarAsync(ProdutoDto dto)
    {
        var produto = await _repo.ObterPorIdAsync(dto.Id);
        if (produto is null) throw new Exception("Produto não encontrado");

        produto.AlterarPreco(dto.Preco); // Simples para o exemplo
        await _repo.AtualizarAsync(produto);
    }

    public async Task RemoverAsync(long id)
    {
        await _repo.RemoverAsync(id);
    }
}


