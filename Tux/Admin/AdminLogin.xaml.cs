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
using POSDataAccess;

namespace Tux
{
    /// <summary>
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Page
    {
        public AdminLogin()
        {
            InitializeComponent(); Error.Opacity = 0;
        }
        private void CloseApp(object sender, MouseEventArgs e)
        {
            if (!POSDataAccess.DataAccess.CloseApplication()) return;
            Application.Current.Shutdown();
        }

        private void LoginAsCashierClick(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new CashierLogin();
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Authentication.AuthenticateAdmin(Username.Text, Password.Password)) { Error.Opacity = 1; return; }
                Window admin = new AdminWindows();
                admin.Show();
                Window.GetWindow(this).Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong, check your internet connection and try again.");
            }
        }

        private void clearError(object sender, RoutedEventArgs e)
        {
            Error.Opacity = 0;
        }
    }

}
