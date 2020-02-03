using POSDataAccess;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System;

namespace Tux
{
    /// <summary>
    /// Interaction logic for CashierLogin.xaml
    /// </summary>
    public partial class CashierLogin : Page
    {
 
        public CashierLogin()
        {
            InitializeComponent();
        }

        private void CloseApp(object sender, MouseEventArgs e)
        {
            if (POSDataAccess.DataAccess.CloseApplication()) Window.GetWindow(this).Close();
        }

        private void LoginAsAdminClick(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Content = new AdminLogin();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!Authentication.AuthenticateCashier(Username.Text, Password.Password)) { Error.Opacity = 1; return; }
                CashierWindow cashier = new CashierWindow();
                cashier.EmployeeID = 1;//Authentication.SessionInfo(Username.Text, Password.Password);
                cashier.Show(); Window.GetWindow(this).Close();
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
