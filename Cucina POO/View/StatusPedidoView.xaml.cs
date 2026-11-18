using Cucina_POO.Controller;
using Cucina_POO.Data;
using Cucina_POO.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Controls;

namespace Cucina_POO.View
{
    public partial class StatusPedidosView : UserControl
    {
        public StatusPedidosView()
        {
            InitializeComponent();
            Loaded += (_, _) => CarregarPedidos();
        }

        private void CarregarPedidos()
        {
            try
            {
                using var context = new CucinaDbContext(new DbContextOptions<CucinaDbContext>());
                ListaPedidos.ItemsSource = new PedidoController(context).RecuperarPedidosComStatus();
            }
            catch (Exception ex)
            {
                ListaPedidos.ItemsSource = Array.Empty<PedidoDTO>();
                System.Windows.MessageBox.Show("Erro ao carregar pedidos: " + ex.Message);
            }
        }
    }
}