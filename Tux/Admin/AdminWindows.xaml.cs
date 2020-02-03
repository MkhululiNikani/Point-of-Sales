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
//using POSController;

namespace Tux
{
    /// <summary>
    /// Interaction logic for AdminWindows.xaml
    /// </summary>
    public partial class AdminWindows : Window
    {
        public AdminWindows()
        {
            InitializeComponent();
        }

        private void CloseApp(object sender, MouseEventArgs e)
        {
            if (!POSDataAccess.DataAccess.CloseApplication()) return;
            Application.Current.Shutdown();
        }
        private void Minimize(object sender, MouseEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Logout(object sender, MouseButtonEventArgs e)
        {
            Welcome welcomeScreen = new Welcome();
            welcomeScreen.Show();
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Close();
        }



        private void ProductClick(object sender, MouseButtonEventArgs e)
        {
            colorItems(0);
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Products();
        }

        private void CartegoriesClick(object sender, MouseButtonEventArgs e)
        {
            colorItems(1);
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Cartegories();
        }

        private void SuppliersClick(object sender, MouseButtonEventArgs e)
        {
            colorItems(2);
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Suppliers();
        }
        
        private void EmployeesClick(object sender, MouseButtonEventArgs e)
        {
            colorItems(3);
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Employees();
        }

        public void colorItems(int i)
        {
            switch (i)
            {
                case 0:

                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));

                    break;
                case 1:
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    break;
                case 2:
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    break;
                case 3:
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    break;
                default:
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ProductIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e36a6a"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().CartegoriesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().SuppliersText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesIcon.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().EmployeesText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989898"));
                    break;
            }
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            colorItems(0);
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Products();
            
        }

        
    }
}
