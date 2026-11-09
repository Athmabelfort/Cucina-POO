
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucina_POO.Model
{
    internal class ItemDePedido
    {
        public long Id { get; set; }

        [Required]
        [ForeignKey("Pedido")]
        public long IdPedido { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public long IdProduto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public string Descricao { get; set; }

        // Propriedades de navegação
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }
    }
}
