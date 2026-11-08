using Cucina_POO.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cucina_POO.View
{
    
    public partial class MainWindow : Window
    {
        NovoPedidoView telaPedido = new NovoPedidoView();
        CadastroProdutoView telaProduto = new CadastroProdutoView();
        CadastroClienteWindow telaCliente = new CadastroClienteWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPedido_Checked(object sender, RoutedEventArgs e)
        {
            AreaConteudo.Content = telaPedido;
        }

        private void BtnProdutos_Checked(object sender, RoutedEventArgs e)
        {
            AreaConteudo.Content = telaProduto;
        }

        private void BtnStatus_Checked(object sender, RoutedEventArgs e)
        {
            AreaConteudo.Content = new StatusPedidosView();
        }
    }
}