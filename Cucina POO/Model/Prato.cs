using System.ComponentModel.DataAnnotations;

namespace Cucina_POO.Model
{
    internal class Prato : Produto, IPreparacao
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
