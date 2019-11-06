﻿using System;
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
        List<CheckBox> boxes;
        public MainWindow()
        {
            InitializeComponent();
            products = new List<Product>();
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
            boxes = new List<CheckBox>();
            foreach (CheckBox item in ToysContainer.Children)
            {
                boxes.Add(item);
            }
            foreach (CheckBox item in MoviesContainer.Children)
            {
                boxes.Add(item);
            }
            foreach (CheckBox item in ComicsContainer.Children)
            {
                boxes.Add(item);
            }
            foreach (CheckBox item in gadgetsContainer.Children)
            {
                boxes.Add(item);
            }
            
        }


        public void GetDetail(string product_name)
        {
            var query = from product in products where product.Name == product_name select product;
            Product p = query.FirstOrDefault();
            var bind = new Binding("Name") {
                Source = p
            };
            DetailName.SetBinding(TextBlock.TextProperty, bind);
            bind = new Binding("Image")
            {
                Source = p
            };
            DI.SetBinding(Image.SourceProperty, bind);
            bind = new Binding("Price")
            {
                Source = p
            };
            DetailPrice.SetBinding(TextBlock.TextProperty, bind);


            //detailImage.ImageSource = ImageSource.Equals(temp.Image);
            //DI.Source = new BitmapImage(new Uri(temp.Image, UriKind.Relative));

        }


        private void GetProducts(List<string> genres)
        {
            products = new List<Product>();
            List<Product> temp = new List<Product>();
            DataTable dt;
            Product data = new Product();
            //dt = p.Listing();
            foreach (var genre in genres)
            {
                dt = data.ListingByGenre(genre);
                temp = (from DataRow dr in dt.Rows
                            select new Product()
                            {
                                Name = (string)dr["full_name"],
                                Price = Convert.ToDouble( dr["price"]),
                                Image = (byte[])dr["image"]
                            
                            }).ToList();

                foreach (var item in temp)
                {
                    products.Add(item);
                }
            }
            if (products.Count > 0)
            {
                Listviewproducts.ItemsSource = products;
            }
            temp.Clear();

        }


        private void Btn_Action(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            List<string> names = new List<string>();
            foreach (CheckBox item in boxes)
            {
                if (item.IsChecked.Value)
                {
                    string sub = item.Name.Substring(3);
                    names.Add(sub);
                   
                }
            }
            GetProducts(names);
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
