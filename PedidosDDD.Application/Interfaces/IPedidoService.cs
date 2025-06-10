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
    Task<PedidoDto?> ObterPorIdAsync(Guid id);
    Task<Guid> CriarAsync(List<ItemPedidoDto> itens);
    Task FinalizarAsync(Guid id);
    Task CancelarAsync(Guid id);
}
