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
using System.Data.SqlClient;
using System.Data;

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
                { "btnSignIn" , ScreenSignIn},
                { "btnDetail" , ScreenDetail},
            };
            ScreenController.SetWindow(screens);
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
            var query = from product in products where product.Name == name select product;
            Product temp = query.FirstOrDefault();
            DetailName.Text = temp.Name;
            DetailPrice.Text = "$" + temp.Price;
            //DI.Source = new BitmapImage(new Uri(temp.Image, UriKind.Relative));
            
        }


        private List<Product> GetProducts()
        {
            List<Product> products = new List<Product>(10);
            DataTable dt;
            Product p = new Product();
            dt = p.Listing();
            Random r = new Random();
            //for (int i = 0; i < 15; i++)
            //{
            //    products.Add(new Product($"Prod {i}", r.Next(5,50), $"/Img/Movies/Horror/{i}.jpg"));
            //}
            products = (from DataRow dr in dt.Rows
                        select new Product()
                        {
                            Name = (string)dr["full_name"],
                            Price = Convert.ToDouble( dr["price"]),
                            Image = (byte[])dr["image"]
                            
                        }).ToList();
            return products;
        }


        //private void ScreenManager(string name)
        //{
        //    screens[name].Visibility = Visibility.Visible;
        //    foreach (var key in screens.Keys)
        //    {
        //        if (!key.Equals(name))
        //        {
        //            screens[key].Visibility = Visibility.Hidden;
        //        }
        //    }
        //}


        private void Btn_Action(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            ScreenController.ControlVisibility(button.Name);
        }

        private void On_Click_SignIn(object sender, RoutedEventArgs e)
        {
            var userName = txtSignInName.Text;
            var pass = txtSignInPass.Password;

            if (pass=="123" && userName=="admin")//buscar en base de datos
            {
                txtUser.Text = userName;
                signInWarning.Visibility = Visibility.Hidden;
                //ScreenManager("btnHome");
                ScreenController.ControlVisibility("btnHome");
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
                ScreenController.ControlVisibility("btnHome");
                btnLogOut.Visibility = Visibility.Visible;

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
            ScreenController.ControlVisibility(b.Name);
            GetDetail(name);
        }

        private void On_Click_Back(object sender, RoutedEventArgs e)
        {
            ScreenDetail.Visibility = Visibility.Hidden;
            ScreenController.ControlVisibility("btnSearch");
        }
    }
}
