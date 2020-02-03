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
    /// Interaction logic for AddCartegory.xaml
    /// </summary>
    public partial class AddCartegory : Page
    {
        public AddCartegory()
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

        private void AddTheCartegoryToDatabase(object sender, RoutedEventArgs e)
        {
            if (!validateInformation()) return;
            AdminScreenController.AddCategory(CartegoryName.Text, Description.Text);
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 1;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Cartegories();
            Application.Current.Windows.OfType<AdminOparationsWindow>().FirstOrDefault().Close();

        }

        public bool validateInformation()
        {
            if (!Validate.Name(CartegoryName.Text)) { MessageBox.Show("Enter a correct Category name"); return false; }
            if (!Validate.Name(Description.Text)) { MessageBox.Show("Enter a correct description"); return false; }

            return true;
        }
    }
}
