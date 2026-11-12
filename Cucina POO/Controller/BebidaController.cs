using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cucina_POO.Controller
{
    internal class BebidaController
    {
        private readonly CucinaDbContext _context;

        public BebidaController(CucinaDbContext context)
        {
            _context = context;
        }

        public void CriaBebida(BebidaDTO dto)
        {
            var bebeida = new Bebida()
            {
                Nome = dto.Nome,
                Preco = dto.Preco,
                Tamanho = dto.Tamanho,
                IdRestaurante = dto.IdRestaurante,
            };

            _context.Bebidas.Add(bebeida);
            _context.SaveChanges();
        }
    }
}
