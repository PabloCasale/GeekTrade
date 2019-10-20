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
using GTBusinessLayer;

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
            List<string> screens = new List<string>()
            {
                ScreenListView.Name,
                ScreenLogin.Name,
                ScreenNews.Name,
                ScreenSignIn.Name
            };
            var user = new User();
            txtUser.Text = user.GetRole();

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
            
        }



        private void ScreenManager()
        {

        }

        private void Btn_Action(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "btnSignIn":
                    //Todavia no termine esto
                    break;
                case "btnLogin":
                    
                    break;
                default:
                    break;
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            ScreenNews.Visibility = Visibility.Visible ;
            ScreenListView.Visibility = Visibility.Hidden ;
        }
    }
}
