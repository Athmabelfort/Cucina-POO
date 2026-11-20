using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;
using Microsoft.EntityFrameworkCore;

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
            var pedidos = _context.Database
                .SqlQuery<PedidoDTO>($"""
            SELECT
                p.Id,
                p.Descricao,
                p.IdCliente,
                c.Nome AS ClienteNome,
                p.Status,
                CASE p.Status
                    WHEN 0 THEN 'Pedido registrado'
                    WHEN 1 THEN 'Em preparação na cozinha'
                    WHEN 2 THEN 'Pronto para retirada'
                    WHEN 3 THEN 'Finalizado'
                END AS StatusDescricao
            FROM Pedidos p
            INNER JOIN Clientes c ON c.Id = p.IdCliente
            WHERE p.Status <> 3
            """)
                .ToList();

            return pedidos;
        }
    }
}
