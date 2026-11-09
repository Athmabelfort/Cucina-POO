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

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentNullException(nameof(produto));
            }

            produto.IdRestaurante = Id;
            produto.Restaurante = this;
            Produtos.Add(produto);
        }

        public decimal ObterValorTotalDoCardapio()
        {
            decimal total = 0;

            foreach (Produto produto in Produtos)
            {
                total += produto.CalcularPrecoFinal();
            }

            return total;
        }

        public void PrepararItensDaCozinha()
        {
            foreach (Produto produto in Produtos)
            {
                IPreparacao preparavel = produto as IPreparacao;

                if (preparavel != null)
                {
                    preparavel.Preparar();
                }
            }
        }
    }
}
