using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cucina_POO.Model
{
    internal class ItemDePedido
    {
        public long Id { get; set; }

        [Required]
        [ForeignKey("Pedido")]
        public long IdPedido { get; set; }

        [Required]
        public string Descricacao { get; set; }

        //Propriedades de navegação
        public Pedido Pedido { get; set; }
    }
}
