using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cucina_POO.Repository
{
    public enum EnumStatusPedido
    {
        [Description("Pedido registrado")]
        Pendente,

        [Description("Em preparação na cozinha")]
        Preparacao,

        [Description("Pronto para retirada")]
        Pronto,

        [Description("Finalizado")]
        Finalizado
    }
}
