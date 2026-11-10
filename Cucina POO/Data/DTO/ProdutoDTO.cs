using Cucina_POO.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucina_POO.Data.DTO
{
    internal abstract class ProdutoDTO
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Range(typeof(decimal), "0.01", "99999999.99")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [ForeignKey("Restaurante")]
        public long IdRestaurante { get; set; }

        //Propriedades de navegação
        public RestauranteDTO Restaurante { get; set; }

        public ICollection<ItemDePedidoDTO> ItensDePedido { get; set; }
            = new List<ItemDePedidoDTO>();

        public abstract string ObterDescricao();

        public virtual decimal CalcularPrecoFinal()
        {
            return Preco;
        }
        public override string ToString()
        {
            return $"{Nome} - R$ {CalcularPrecoFinal():F2}";
        }
    }
}