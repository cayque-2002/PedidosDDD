using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PedidosDDD.Application.DTOs;

namespace PedidosDDD.Application.Interfaces;

public interface IProdutoService
{
    Task<IEnumerable<ProdutoDto>> ObterTodosAsync();
    Task<ProdutoDto?> ObterPorIdAsync(long id);
    Task AdicionarAsync(ProdutoDto dto);
    Task AtualizarAsync(ProdutoDto dto);
    Task RemoverAsync(long id);
}

