using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Cucina_POO.Model
{
    internal class Restaurante
    {
        public long Id { get; set; }

        //Propriedades de navegação
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
