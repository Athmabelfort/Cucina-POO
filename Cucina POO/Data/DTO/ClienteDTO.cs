using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cucina_POO.Data.DTO
{
    internal class ClienteDTO
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public long IdEndereco { get; set; }
    }
}
