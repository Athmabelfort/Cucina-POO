using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cucina_POO.Model
{
    internal class Endereco
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

        [Required]
        public long IdCliente { get; set; }

        public long? IdRestaurante { get; set; }

        // Propriedades de navegação
        public Cliente Cliente { get; set; }
        public Restaurante Restaurante { get; set; }

    }
}
