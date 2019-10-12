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
using GTBusiness;

namespace GeekTrade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            var products = GetProducts();
            if (products.Count > 0)
            {
                Listviewproducts.ItemsSource = products;
            }

        }

        private List<Product> GetProducts()
        {
            var p = new List<Product>();
            for (int i = 0; i < 20; i++)
            {
                p.Add(new Product($"Prod {i}", 784.56, "/Img/Icons/dk.jpg"));
            }
            return p;
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            ScreenNews.Visibility = Visibility.Hidden;
            ScreenListView.Visibility = Visibility.Visible;
            //Test branch
        }
    }
}
