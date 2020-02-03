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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
        }

        DataTable data = new DataTable();
        private void AddProduct(object sender, RoutedEventArgs e)
        {
            AdminOparationsWindow AddWindow = new AdminOparationsWindow();
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = false;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 0.7;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            AddWindow.Content = new AddProduct();
            AddWindow.Show();
        }

        private void ProductsLoaded(object sender, RoutedEventArgs e)
        {
            ProductsGrid.ItemsSource = AdminScreenController.LoadAllProducts().DefaultView;
        }

        private void UpdateAll(object sender, RoutedEventArgs e)
        {
            AdminScreenController.UpdateAllProducts(((DataView)ProductsGrid.ItemsSource).ToTable());
            this.DataContext = new Products();
        }

        
    }
}
