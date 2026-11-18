using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<ProdutoDTO> RecuperarProdutos()
        {
            var pratos = _context.Pratos.Select(p => new PratoDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                IdRestaurante = p.IdRestaurante
            }).ToList();

            var bebidas = _context.Bebidas.Select(p => new BebidaDTO
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Tamanho = p.Tamanho,
                IdRestaurante = p.IdRestaurante
            }). ToList();

            return pratos.Cast<ProdutoDTO>().Concat(bebidas).ToList();
        }
    }
}
