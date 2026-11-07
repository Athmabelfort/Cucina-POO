using System.Windows;

namespace Cucina_POO.View
{
    public partial class CadastroClienteWindow : Window
    {
        public string Nome => TxtNome.Text;
        public string Endereco => TxtEndereco.Text;
        public string Cpf => TxtCpf.Text;
        public string Telefone => TxtTelefone.Text;

        public CadastroClienteWindow(string nomeInicial = "")
        {
            InitializeComponent();
            TxtNome.Text = nomeInicial;

            Loaded += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(nomeInicial)) TxtNome.Focus();
                else TxtEndereco.Focus();
            };
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}