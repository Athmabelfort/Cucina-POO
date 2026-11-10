using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cucina_POO.Data.DTO
{
    internal class EnderecoDTO
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public long IdCliente { get; set; }

        public long? IdRestaurante { get; set; }
    }
}
