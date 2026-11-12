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
        public decimal Preco { get; set; }

        [Required]
        public long IdRestaurante { get; set; }

        public abstract string ObterDescricao();

        public virtual decimal CalcularPrecoFinal()
        {
            return Preco;
        }
    }
}