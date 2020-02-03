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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Page
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 1;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            Application.Current.Windows.OfType<AdminOparationsWindow>().FirstOrDefault().Close();
        }

        private void AddEmployeeToDatabase(object sender, RoutedEventArgs e)
        {
            if (!validateInformation()) return;
            AdminScreenController.AddEmployee(LastName.Text, FirstName.Text, Title.Text, IDNO.Text, Address.Text, ReportsTo.Text, Email.Text, PositionID.Text, Username.Text, Password.Text);
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 1;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Employees();
            Application.Current.Windows.OfType<AdminOparationsWindow>().FirstOrDefault().Close();
        }

        public bool validateInformation()
        {
            if (!Validate.Name(LastName.Text)) { MessageBox.Show("Enter a correct Lastname"); return false; }
            if (!Validate.Name(FirstName.Text)) { MessageBox.Show("Enter a correct Firstname"); return false; }
            if (!Validate.Name(Title.Text)) { MessageBox.Show("Enter a correct Title"); return false; }
            if (!Validate.IDNumber(IDNO.Text)) { MessageBox.Show("Enter a correct IDNumber"); return false; }
            if (!Validate.AlphaNumeric(Address.Text)) { MessageBox.Show("Enter a correct Address"); return false; }
            if (!Validate.Number(ReportsTo.Text)) { MessageBox.Show("Enter a correct ReportsTo ID"); return false; }
            if (!Validate.Email(Email.Text)) { MessageBox.Show("Enter a correct Email Address"); return false; }
            if (!Validate.Number(PositionID.Text)) { MessageBox.Show("Enter a correct Position ID"); return false; }
            if (!Validate.AlphaNumeric(Username.Text)) { MessageBox.Show("Username only allows Numbers, Letters, - and _"); return false; }

            return true;
        }

    }
}
