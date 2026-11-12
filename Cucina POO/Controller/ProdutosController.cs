using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cucina_POO.Controller
{
    internal class ProdutosController
    {
        private readonly CucinaDbContext _context;

        public ProdutosController(CucinaDbContext context)
        {
            _context = context;
        }

        public void CriarProduto(ProdutoDTO dto)
        {
            var pratoController = new PratoController(_context);
            var bebidaController = new BebidaController(_context);
            if (dto != null)
            {
                if (dto is PratoDTO pratoDTO)
                {
                    pratoController.CriaPrato(pratoDTO);
                }
                else if (dto is BebidaDTO bebidaDTO)
                {
                    bebidaController.CriaBebida(bebidaDTO);
                }
            }
            else
            {
                throw new Exception();
            }  
        }
    }
}
