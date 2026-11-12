using Cucina_POO.Model.Interface;
using System.ComponentModel.DataAnnotations;

namespace Cucina_POO.Data.DTO
{
    internal class PratoDTO : ProdutoDTO, IPreparacao
    {
        [MaxLength(400)]
        public string Descricao { get; set; }

        public void Preparar()
        {
            // Regra de preparo do prato (ex.: enviar para a cozinha, marcar início do preparo).
        }

        public override string ObterDescricao()
        {
            return $"{Nome} - {Descricao}";
        }
    }
}
