
using Cucina_POO.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucina_POO.Data.DTO
{
    internal class ItemDePedidoDTO
    {
        public long Id { get; set; }

        [Required]
        public long IdPedido { get; set; }

        [Required]
        public long IdProduto { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }
    }
}
