
using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cucina_POO.Controller
{
    internal class ClienteController
    {
        private readonly CucinaDbContext _context;

        public ClienteController(CucinaDbContext context)
        {
            _context = context;
        }

        public void CriarCliente(ClienteDTO dto, EnderecoDTO enderecoDTO)
        {
            if (dto == null || enderecoDTO == null)
            {
                throw new ArgumentNullException("Os dados do cliente e do endereço não podem ser nulos.");
            }

            var endereco = new Endereco()
            {
                Logradouro = enderecoDTO.Logradouro,
                Numero = enderecoDTO.Numero,
                Complemento = enderecoDTO.Complemento,
                CEP = enderecoDTO.CEP,
                IdRestaurante = 1
            };

            var cliente = new Cliente()
            {
                Nome = dto.Nome,
                Endereco = endereco
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public List<ClienteDTO> RecuperarClientes()
        {
            return _context.Clientes
                .OrderBy(c => c.Nome)
                .Select(c => new ClienteDTO
                {
                    Id = c.Id,
                    Nome = c.Nome
                })
                .ToList();
        }
    }
}
