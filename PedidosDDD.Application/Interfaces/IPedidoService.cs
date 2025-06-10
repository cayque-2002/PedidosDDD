using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PedidosDDD.Application.DTOs;

namespace PedidosDDD.Application.Interfaces;

public interface IPedidoService
{
    Task<IEnumerable<PedidoDto>> ObterTodosAsync();
    Task<PedidoDto?> ObterPorIdAsync(long id);
    Task<long> CriarAsync(List<ItemPedidoDto> itens);
    Task FinalizarAsync(long id);
    Task CancelarAsync(long id);
}
