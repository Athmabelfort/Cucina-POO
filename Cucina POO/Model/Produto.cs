using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cucina_POO.Model
{
    internal abstract class Produto
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [ForeignKey("Restaurante")]
        public long IdRestaurante { get; set; }

        //Propriedades de navegação
        public Restaurante Restaurante { get; set; }

        // Depende de ItemDePedido ganhar IdProduto/Produto para ser habilitada.
        // public ICollection<ItemDePedido> ItensDePedido { get; set; }

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
