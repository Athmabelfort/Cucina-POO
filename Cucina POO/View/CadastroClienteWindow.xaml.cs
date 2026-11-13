
using Cucina_POO.Controller;
using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Cucina_POO.View
{
    public partial class CadastroClienteWindow : Window
    {
        public string Nome => TxtNome.Text.Trim();

        public CadastroClienteWindow(string nomeInicial = "")
        {
            InitializeComponent();

            TxtNome.Text = nomeInicial;

            Loaded += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(nomeInicial))
                    TxtNome.Focus();
                else
                    TxtLogradouro.Focus();
            };
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Nome) ||
                string.IsNullOrWhiteSpace(TxtLogradouro.Text) ||
                !int.TryParse(TxtNumero.Text, out int numero) ||
                numero <= 0 ||
                string.IsNullOrWhiteSpace(TxtComplemento.Text) ||
                string.IsNullOrWhiteSpace(TxtCEP.Text))
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
                return;
            }

            try
            {
                var clienteDTO = new ClienteDTO
                {
                    Nome = Nome
                };

                var enderecoDTO = new EnderecoDTO
                {
                    Logradouro = TxtLogradouro.Text.Trim(),
                    Numero = numero,
                    Complemento = TxtComplemento.Text.Trim(),
                    CEP = TxtCEP.Text.Trim()
                };

                using var context = new CucinaDbContext(
                    new DbContextOptions<CucinaDbContext>());

                var controller = new ClienteController(context);

                controller.CriarCliente(clienteDTO, enderecoDTO);

                MessageBox.Show("Cliente cadastrado com sucesso!");

                DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar cliente: " + ex.Message);
            }
        }
    }
}
