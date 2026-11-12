
using System.ComponentModel.DataAnnotations;

namespace Cucina_POO.Data.DTO
{
    internal class ClienteDTO
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
