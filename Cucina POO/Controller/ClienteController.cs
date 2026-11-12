
using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Model;

namespace Cucina_POO.Controller
{
    internal class ClienteController
    {
        private readonly CucinaDbContext _context;

        public ClienteController(CucinaDbContext context)
        {
            _context = context;
        }

        public void CriarCliente(ClienteDTO clienteDTO, EnderecoDTO enderecoDTO)
        {
            var cliente = new Cliente()
            {
                Nome = clienteDTO.Nome
            };

            cliente.Endereco.Add(new Endereco()
            {
                Logradouro = enderecoDTO.Logradouro,
                Numero = enderecoDTO.Numero,
                Complemento = enderecoDTO.Complemento,
                CEP = enderecoDTO.CEP
            });

            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
    }
}
