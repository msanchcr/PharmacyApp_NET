using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PharmacyApp_NET.core;

namespace PharmacyApp_NET
{
    /// <summary>
    /// Lógica de interacción para DistributorWindow.xaml
    /// </summary>
    public partial class DistributorWindow : Window
    {
        Order order;

        public DistributorWindow(Order order)
        {
            InitializeComponent();
            this.order = order;
            Tb_order.Text = order.toString();
        }

        private void Btn_send_Click(object sender, RoutedEventArgs e)
        {
            if (this.order != null)
            {
                MessageBox.Show($"The order {this.order.toString()} has been delivered.");
            }
            this.Close();
        }

        private void Btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.order != null)
            {
                MessageBox.Show($"The order {this.order.toString()} has been cancelled.");
            }
            this.Close();
        }
    }
}
