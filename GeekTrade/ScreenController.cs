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
    public static class ScreenController
    {
        static Dictionary<string, Border> screens;
        public static void ControlVisibility(string name)
        {
            screens[name].Visibility = Visibility.Visible;
            foreach (var key in screens.Keys)
            {
                if (!key.Equals(name))
                {
                    screens[key].Visibility = Visibility.Hidden;
                }
            }
        }

        public static void SetWindow(Dictionary<string,Border> windows)
        {
            screens = windows;
        }
    }
}
