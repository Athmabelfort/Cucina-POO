
using Cucina_POO.Controller;
using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Cucina_POO.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cucina_POO.View
{
    public partial class NovoPedidoView : UserControl
    {
        private readonly ObservableCollection<ItemPedidoView> _itens = new();

        public NovoPedidoView()
        {
            InitializeComponent();

            ListaItens.ItemsSource = _itens;
            BtnAdicionar.Click += BtnAdicionar_Click;
            BtnRealizar.Click += BtnRealizar_Click;
            BtnCancelar.Click += BtnCancelar_Click;

            CmbCliente.PreviewKeyDown += CmbCliente_PreviewKeyDown;
            CarregarDados();
        }

        private void CarregarDados()
        {
            using var context = new CucinaDbContext(new DbContextOptions<CucinaDbContext>());
            var produtos = new ProdutosController(context).RecuperarProdutos();
            var clientes = new ClienteController(context).RecuperarClientes();

            CmbProduto.ItemsSource = produtos;
            CmbProduto.DisplayMemberPath = "Nome";
            CmbProduto.SelectedValuePath = "Id";

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
                using var contextoClientes = new CucinaDbContext(new DbContextOptions<CucinaDbContext>());
                CmbCliente.ItemsSource = new ClienteController(contextoClientes).RecuperarClientes();

                var novoCliente = ((IEnumerable<ClienteDTO>)CmbCliente.ItemsSource)
                    .FirstOrDefault(c => c.Nome == nome);

                if (novoCliente != null)
                    CmbCliente.SelectedItem = novoCliente;
            }
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (CmbProduto.SelectedItem is not ProdutoDTO produto ||
                !int.TryParse(TxtQuantidade.Text, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Selecione um produto e informe uma quantidade válida.");
                return;
            }

            var itemExistente = _itens.FirstOrDefault(i => i.Produto.Id == produto.Id);
            if (itemExistente != null)
                itemExistente.Quantidade += quantidade;
            else
                _itens.Add(new ItemPedidoView(produto, quantidade));

            ListaItens.Items.Refresh();
            AtualizarTotal();
        }

        private void BtnRealizar_Click(object sender, RoutedEventArgs e)
        {
            decimal total = _itens.Sum(i => i.Subtotal);

            if (total <= 0)
            {
                MessageBox.Show("Adicione ao menos um produto antes de realizar o pagamento.");
                return;
            }

            if (CmbCliente.SelectedItem is not ClienteDTO cliente)
            {
                MessageBox.Show("Selecione um cliente antes de realizar o pagamento.");
                return;
            }

            try
            {
                using var context = new CucinaDbContext(new DbContextOptions<CucinaDbContext>());
                var dto = new PedidoDTO
                {
                    IdCliente = cliente.Id,
                    Status = EnumStatusPedido.Pendente,
                    Descricao = string.Join(", ", _itens.Select(i => $"{i.Produto.Nome} x{i.Quantidade}")),
                    ItensDePedido = _itens.Select(i => new ItemDePedidoDTO
                    {
                        IdProduto = i.Produto.Id,
                        Quantidade = i.Quantidade
                    }).ToList()
                };

                new PedidoController(context).CriarPedido(dto);
                MessageBox.Show("Pagamento processado e pedido gerado com sucesso!");
                LimparPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar pedido: " + ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e) => LimparPedido();

        private void LimparPedido()
        {
            _itens.Clear();
            CmbCliente.SelectedItem = null;
            CmbProduto.SelectedItem = null;
            TxtQuantidade.Text = "1";
            AtualizarTotal();
        }

        private void AtualizarTotal()
        {
            decimal total = _itens.Sum(i => i.Subtotal);
            TxtTotal.Text = total.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
            BtnRealizar.IsEnabled = total > 0;
        }

        private sealed class ItemPedidoView
        {
            public ProdutoDTO Produto { get; }
            public int Quantidade { get; set; }
            public decimal Preco => Produto.CalcularPrecoFinal();
            public decimal Subtotal => Preco * Quantidade;

            public ItemPedidoView(ProdutoDTO produto, int quantidade)
            {
                Produto = produto;
                Quantidade = quantidade;
            }
        }
    }
}
