using Cucina_POO.Repository;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucina_POO.Model
{
    internal class Pedido
    {
        public long Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public EnumStatusPedido Status { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public long IdCliente { get; set; }

        //Propriedades de navegação
        public ICollection<ItemDePedido> ItemDePedido { get; set; }
        public Cliente Cliente { get; set; }
    }
}
