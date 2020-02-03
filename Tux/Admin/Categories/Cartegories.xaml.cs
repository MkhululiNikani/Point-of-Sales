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
    /// Interaction logic for Cartegories.xaml
    /// </summary>
    public partial class Cartegories : Page
    {
        public Cartegories()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs a)
        {
            CategoriesGrid.ItemsSource = AdminScreenController.LoadAllCategories().DefaultView;
        }

        private void AddCartegory(object sender, RoutedEventArgs e)
        {
            AdminOparationsWindow AddWindow = new AdminOparationsWindow();
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = false;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 0.7;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            AddWindow.Content = new AddCartegory();
            AddWindow.Show();
        }

        private void UpdateAll(object sender, RoutedEventArgs e)
        {
            AdminScreenController.UpdateAllCategories(((DataView)CategoriesGrid.ItemsSource).ToTable());
            this.DataContext = new Cartegories();
        }
    }
}
