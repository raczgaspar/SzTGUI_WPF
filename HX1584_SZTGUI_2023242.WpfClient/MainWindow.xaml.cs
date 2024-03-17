using HX1584_SZTGUI_2023242.WpfClient.CartWpf;
using HX1584_SZTGUI_2023242.WpfClient.CustomerWpf;
using HX1584_SZTGUI_2023242.WpfClient.ItemWpf;
using HX1584_SZTGUI_2023242.WpfClient.OrderWpf;
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

namespace HX1584_SZTGUI_2023242.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow cw = new CustomerWindow();
            cw.Show();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow ow = new OrderWindow();
            ow.Show();
        }

        private void Cart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cw = new CartWindow();
            cw.Show();
        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            ItemWindow iw = new ItemWindow();
            iw.Show();
        }
    }
}
