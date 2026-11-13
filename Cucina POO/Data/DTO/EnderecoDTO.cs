
using System.ComponentModel.DataAnnotations;

namespace Cucina_POO.Data.DTO
{
    internal class EnderecoDTO
    {
        public long Id { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Complemento { get; set; }

        [Required]
        public string CEP { get; set; }

        public string Complemento { get; set; }

        public long? IdRestaurante { get; set; }
    }
}
