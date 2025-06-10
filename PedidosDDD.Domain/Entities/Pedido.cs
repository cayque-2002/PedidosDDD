using PedidosDDD.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDDD.Domain.Entities;

public class Pedido
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
    public List<ItemPedido> Itens { get; private set; } = new();
    public StatusPedido Status { get; private set; } = StatusPedido.AguardandoPagamento;

    public Pedido() { }

    public void AdicionarItem(ItemPedido item)
    {
        if (Itens.Any(i => i.ProdutoId == item.ProdutoId))
            throw new InvalidOperationException("Produto já adicionado ao pedido.");

        Itens.Add(item);
    }

    public decimal CalcularValorTotal() => Itens.Sum(i => i.ValorTotal);

    public void Cancelar()
    {
        if (Status == StatusPedido.Finalizado)
            throw new InvalidOperationException("Pedido já finalizado.");

        Status = StatusPedido.Cancelado;
    }

    public void Finalizar()
    {
        if (!Itens.Any())
            throw new InvalidOperationException("Pedido sem itens não pode ser finalizado.");

        Status = StatusPedido.Finalizado;
    }
}

