using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;

namespace Cucina_POO.Controller
{
    internal class PratoController
    {
        private readonly CucinaDbContext _context;

        public PratoController(CucinaDbContext context)
        {
            _context = context;
        }

        public void CriaPrato(PratoDTO dto)
        {
            var prato = new Prato()
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                Descricao = dto.Descricao,
                IdRestaurante = dto.IdRestaurante,
            };

            _context.Pratos.Add(prato);
            _context.SaveChanges();
        }
    }
}
