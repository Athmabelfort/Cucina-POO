
using Cucina_POO.Data;
using Cucina_POO.View;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cucina_POO.View
{
    public partial class NovoPedidoView : UserControl
    {
        public NovoPedidoView()
        {
            InitializeComponent();

            CarregarProdutos();
            CarregarClientes();

            CmbCliente.PreviewKeyDown += CmbCliente_PreviewKeyDown;
        }

        private void CarregarProdutos()
        {
            using var context = new CucinaDbContext(
                new DbContextOptions<CucinaDbContext>());

            var produtos = context.Produtos
                .OrderBy(p => p.Nome)
                .ToList();

            CmbProduto.ItemsSource = produtos;
            CmbProduto.DisplayMemberPath = "Nome";
            CmbProduto.SelectedValuePath = "Id";
        }

        private void CarregarClientes()
        {
            using var context = new CucinaDbContext(
                new DbContextOptions<CucinaDbContext>());

            var clientes = context.Clientes
                .OrderBy(c => c.Nome)
                .ToList();

            CmbCliente.ItemsSource = clientes;
            CmbCliente.DisplayMemberPath = "Nome";
            CmbCliente.SelectedValuePath = "Id";
        }

        private void CmbCliente_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
                return;

            string nome = CmbCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
                return;

            using var context = new CucinaDbContext(
                new DbContextOptions<CucinaDbContext>());

            var cliente = context.Clientes
                .FirstOrDefault(c => c.Nome == nome);

            if (cliente != null)
            {
                CmbCliente.SelectedValue = cliente.Id;
                return;
            }

            MessageBoxResult resposta = MessageBox.Show(
                "Cliente não encontrado. Deseja cadastrá-lo?",
                "Cliente não encontrado",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (resposta != MessageBoxResult.Yes)
                return;

            var janela = new CadastroClienteWindow(nome)
            {
                Owner = Window.GetWindow(this)
            };

            if (janela.ShowDialog() == true)
            {
                CarregarClientes();

                using var novoContext = new CucinaDbContext(
                    new DbContextOptions<CucinaDbContext>());

                var novoCliente = novoContext.Clientes
                    .FirstOrDefault(c => c.Nome == nome);

                if (novoCliente != null)
                {
                    CmbCliente.SelectedValue = novoCliente.Id;
                }
            }
        }
    }
}
