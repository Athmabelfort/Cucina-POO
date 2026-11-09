using System.ComponentModel.DataAnnotations;

namespace Cucina_POO.Model
{
    internal class Bebida : Produto
    {
        [Required]
        [MaxLength(20)]
        public string Tamanho { get; set; }

        public override string ObterDescricao()
        {
            return $"{Nome} ({Tamanho})";
        }

        public override decimal CalcularPrecoFinal()
        {
            decimal precoBase = base.CalcularPrecoFinal();
            return Tamanho == "Grande" ? precoBase * 1.3m : precoBase;
        }
    }
}
