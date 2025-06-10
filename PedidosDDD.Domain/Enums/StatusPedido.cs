using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidosDDD.Domain.Enums;

public enum StatusPedido
{
    AguardandoPagamento = 0,
    Finalizado = 1,
    Cancelado = 2
}
