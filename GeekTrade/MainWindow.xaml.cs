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

        Dictionary<string, Border> screens;
        List<Product> products;
        public MainWindow()
        {
            InitializeComponent();
            screens = new Dictionary<string, Border>()
            {
                { "btnSearch" , ScreenListView },
                { "btnLogIn" , ScreenLogin},
                { "btnHome" , ScreenNews},
                { "btnSignIn" , ScreenSignIn}
            };
            var user = new User();
            txtUser.Text = user.GetRole();

            products = GetProducts();
            if (products.Count > 0)
            {
                Listviewproducts.ItemsSource = products;
            }
            
        }


        public void GetDetail(string name)
        {
            
            DetailName.Text = name;
            DetailPrice.Text = "$"+ products[0].Price.ToString();
            DI.Source = new BitmapImage(new Uri(@"/Img/Icons/dk.jpg", UriKind.Relative));
            
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


        private void ScreenManager(string name)
        {
            screens[name].Visibility = Visibility.Visible;
            foreach (var k in screens.Keys)
            {
                if (!k.Equals(name))
                {
                    screens[k].Visibility = Visibility.Hidden;
                }
            }
        }


        private void Btn_Action(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ScreenManager(button.Name);
        }

        private void On_Click_SignIn(object sender, RoutedEventArgs e)
        {
            var userName = txtSignInName.Text;
            var pass = txtSignInPass.Password;

            if (pass=="123" && userName=="admin")//buscar en base de datos
            {
                txtUser.Text = userName;
                signInWarning.Visibility = Visibility.Hidden;
                ScreenManager("btnHome");
            }
            else
            {
                txtSignInName.Text = "";
                txtSignInPass.Password= "";
                signInWarning.Visibility = Visibility.Visible;
            }
        }

        private void On_Click_LogIn(object sender, RoutedEventArgs e)
        {
            var email = txtEmailLogin.Text;
            var pass = passLogIn.Password;

            if (pass == "123" && email == "admin@admin.com")//buscar en base de datos
            {
                txtUser.Text = email;
                signInWarning.Visibility = Visibility.Hidden;
                btnLogIn.Visibility = Visibility.Hidden;
                btnLogOut.Visibility = Visibility.Visible;
                ScreenManager("btnHome");
            }
            else
            {
                txtEmailLogin.Text = "";
                passLogIn.Password = "";
                LogInWarning.Visibility = Visibility.Visible;
            }
        }

        private void On_Click_Info(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            var name = b.DataContext.ToString();
            ScreenDetail.Visibility = Visibility.Visible;
            GetDetail(name);
        }
    }
}
