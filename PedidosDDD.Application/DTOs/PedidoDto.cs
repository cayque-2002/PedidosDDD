using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDDD.Application.DTOs;

public class PedidoDto
{
    public long Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public List<ItemPedidoDto> Itens { get; set; } = new();
    public string Status { get; set; } = string.Empty;
}

public class ItemPedidoDto
{
    public long ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}
