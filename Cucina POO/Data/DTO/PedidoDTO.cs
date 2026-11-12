using Cucina_POO.Model;
using Cucina_POO.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cucina_POO.Data.DTO
{
    internal class PedidoDTO
    {
        public long Id { get; set; }

        [Required]
        public string Descricao { get; set; }


        [Required]
        public long IdCliente { get; set; }

        [Required]
        public string ClienteNome { get; set; }

        [Required]
        public EnumStatusPedido Status { get; set; }

        [Required]
        public string StatusDescricao { get; set; }

        [Required]
        public List<ItemDePedidoDTO> ItensDePedido { get; set; } = new List<ItemDePedidoDTO>();
    }
}
