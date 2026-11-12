using System.ComponentModel.DataAnnotations;

namespace Cucina_POO.Model
{
    internal class Bebida : Produto
    {
        [Required]
        [MaxLength(20)]
        public string Tamanho { get; set; }

     }
}
