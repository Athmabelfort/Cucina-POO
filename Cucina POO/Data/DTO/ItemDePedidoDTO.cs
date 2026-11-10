
using Cucina_POO.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucina_POO.Data.DTO
{
    internal class ItemDePedidoDTO
    {
        public long Id { get; set; }

        [Required]
        [ForeignKey("Pedido")]
        public long IdPedido { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public long IdProduto { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        // Propriedades de navegação
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
