using Cucina_POO.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cucina_POO.Data.DTO
{
    internal class BebidaDTO : ProdutoDTO
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
