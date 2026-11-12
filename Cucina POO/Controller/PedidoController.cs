using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;

namespace Cucina_POO.Controller
{
    internal class PedidoController
    {
        private readonly CucinaDbContext _context;
        public PedidoController(CucinaDbContext context)
        {
            _context = context;
        }
        public void CriarPedido(PedidoDTO dto)
        {
            var pedido = new Pedido()
            {
                Descricao = dto.Descricao,
                Status = dto.Status,
                IdCliente = dto.IdCliente,
                ItemDePedido = new List<ItemDePedido>()
            };

            if (dto.ItensDePedido.Any())
            {
                foreach (var itens in dto.ItensDePedido)
                {
                    pedido.ItemDePedido.Add(new ItemDePedido
                    {
                        IdProduto = itens.IdProduto,
                        Quantidade = itens.Quantidade,
                    });
                }
            }
            //informacao: aq ele só pega o objeto, cria e depois salva no banco
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
        }

        // carregar todos os pedidos ainda não finalizados na tela de status pedido
        public List<PedidoDTO> RecuperarPedidosComStatus()
        {
            var pedidos = _context.Pedidos
                .Where(p => p.Status != Repository.EnumStatusPedido.Finalizado)
                .Select(p => new PedidoDTO
                {
                   Status = p.Status,
                   ClienteNome = p.Cliente.Nome,
                   IdCliente = p.Cliente.Id,
                })
                .ToList();

            return pedidos;
        }
    }
}
