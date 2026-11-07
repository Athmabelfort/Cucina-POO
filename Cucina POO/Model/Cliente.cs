using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cucina_POO.Model
{
    internal class Cliente
    {
        public long Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public long IdEndereco { get; set; }

        //Propriedades de navegação
        public ICollection<Endereco> Endereco { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } 


    }
}
