using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using POSDataAccess;

namespace Tux
{
    /// <summary>
    /// Interaction logic for Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Page
    {
        public Suppliers()
        {
            InitializeComponent();
        }

        private void AddSupplier(object sender, RoutedEventArgs e)
        {
            AdminOparationsWindow AddWindow = new AdminOparationsWindow();
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = false;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 0.7;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            AddWindow.Content = new AddSupplier();
            AddWindow.Show();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            SuppliersGrid.ItemsSource = AdminScreenController.LoadAllSuppliers().DefaultView;
        }

        private void UpdateAll(object sender, RoutedEventArgs e)
        {
            AdminScreenController.UpdateAllSuppliers(((DataView)SuppliersGrid.ItemsSource).ToTable());
            this.DataContext = new Suppliers();
        }


    }
}
