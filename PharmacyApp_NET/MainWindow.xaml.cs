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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PharmacyApp_NET.core;

namespace PharmacyApp_NET
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_send_Click(object sender, RoutedEventArgs e)
        {
            doCreateOrder();
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            doClearForm();
        }

        private void doCreateOrder ()
        {
            string name = Tb_name.Text;
            MedicineType type = (MedicineType)Cb_type.SelectedIndex;
            int amount = 0;
            try
            {
                amount = int.Parse(Tb_amount.Text);
            }
            catch (FormatException ex)
            {
                amount = 0;
            }
            Distributor dist = 0;
            if (Rb_distributor_001.IsChecked == true)
            {
                dist = Distributor.COFARMA;
            }
            if (Rb_distributor_002.IsChecked == true)
            {
                dist = Distributor.EMPSEPHAR;
            }
            if (Rb_distributor_003.IsChecked == true)
            {
                dist = Distributor.CEMEFAR;
            }
            List<Directions> dir = new List<Directions>();
            if (Cb_direction_001.IsChecked == true)
            {
                dir.Add(Directions.ROSA);
            }
            if (Cb_direction_002.IsChecked == true)
            {
                dir.Add(Directions.ALCAZABILLA);
            }
            OrderFactory factory = OrderFactory.getInstance();
            try
            {
                Order order = factory.create(name, type, amount, dist, dir);
                MessageBox.Show($"A new order has been created: {order.toString()}");
                DistributorWindow distWindow = new DistributorWindow(order);
                distWindow.Show();
            }
            catch (ArgumentException arg)
            {
                MessageBox.Show(arg.Message);
            }
        }

        private void doClearForm ()
        {
            Tb_name.Text = "";
            Cb_type.SelectedItem = 0;
            Tb_amount.Text = "0";
            Rb_distributor_001.IsChecked = true;
            Cb_direction_001.IsChecked = false;
            Cb_direction_002.IsChecked = false;
            MessageBox.Show("The request has been cleared.");
        }
    }
}
