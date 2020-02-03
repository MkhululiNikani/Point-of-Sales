using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            AdminOparationsWindow AddWindow = new AdminOparationsWindow();
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = false;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 0.7;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            AddWindow.Content = new AddEmployee();
            AddWindow.Show();
        }

        private void EmployeesLoaded(object sender, RoutedEventArgs e)
        {
            EmployeesGrid.ItemsSource = AdminScreenController.LoadAllEmployees().DefaultView;
        }
        private void UpdateRecords(object sender, RoutedEventArgs e)
        {
            AdminScreenController.UpdateAllEmployees(((DataView)EmployeesGrid.ItemsSource).ToTable());
            this.DataContext = new Employees();
        }
    }
}
