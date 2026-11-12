using System.ComponentModel.DataAnnotations;

namespace Cucina_POO.Model
{
    internal class Prato : Produto
    {
        [MaxLength(400)]
        public string Descricao { get; set; }
    }
}
