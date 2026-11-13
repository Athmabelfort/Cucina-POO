
using Cucina_POO.Controller;
using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Cucina_POO.View
{
    public partial class CadastroProdutoView : UserControl
    {
        public CadastroProdutoView()
        {
            InitializeComponent();

            BtnSalvar.Click += BtnSalvar_Click;
            BtnCancelar.Click += BtnCancelar_Click;
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            string nome = TxtNome.Text.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome do produto.");
                return;
            }

            if (!decimal.TryParse(TxtPreco.Text,
                NumberStyles.Number,
                CultureInfo.GetCultureInfo("pt-BR"),
                out decimal preco) || preco <= 0)
            {
                MessageBox.Show("Informe um preço válido.");
                return;
            }

            try
            {
                using var context = new CucinaDbContext(
                    new DbContextOptions<CucinaDbContext>());

                long idRestaurante = context.Restaurantes
                    .Select(r => r.Id)
                    .FirstOrDefault();

                if (idRestaurante == 0)
                {
                    MessageBox.Show("Nenhum restaurante encontrado no banco.");
                    return;
                }

                ProdutoDTO dto;

                if (RbPrato.IsChecked == true)
                {
                    string descricao = TxtDescricao.Text.Trim();

                    if (string.IsNullOrWhiteSpace(descricao))
                    {
                        MessageBox.Show("Informe a descrição do prato.");
                        return;
                    }

                    dto = new PratoDTO
                    {
                        Nome = nome,
                        Preco = preco,
                        Descricao = descricao,
                        IdRestaurante = idRestaurante
                    };
                }
                else
                {
                    string tamanho = TxtTamanho.Text.Trim();

                    if (string.IsNullOrWhiteSpace(tamanho))
                    {
                        MessageBox.Show("Informe o tamanho da bebida.");
                        return;
                    }

                    dto = new BebidaDTO
                    {
                        Nome = nome,
                        Preco = preco,
                        Tamanho = tamanho,
                        IdRestaurante = idRestaurante
                    };
                }

                var controller = new ProdutosController(context);
                controller.CriarProduto(dto);

                MessageBox.Show("Produto cadastrado com sucesso!");

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            TxtNome.Clear();
            TxtPreco.Clear();
            TxtDescricao.Clear();
            TxtTamanho.Clear();
            RbPrato.IsChecked = true;
        }
    }
}
