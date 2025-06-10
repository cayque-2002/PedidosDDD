using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDDD.Domain.Entities;

public class ItemPedido
{
    public long ProdutoId { get; private set; }
    public int Quantidade { get; private set; }
    public decimal ValorUnitario { get; private set; }

    public decimal ValorTotal => Quantidade * ValorUnitario;

    public ItemPedido(long produtoId, int quantidade, decimal valorUnitario)
    {
        if (quantidade <= 0) throw new ArgumentException("Quantidade deve ser maior que zero");
        if (valorUnitario <= 0) throw new ArgumentException("Valor unitário inválido");

        ProdutoId = produtoId;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }
}

