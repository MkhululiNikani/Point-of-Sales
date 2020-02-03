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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public AddProduct()
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

        private void AddProductToDatabase(object sender, RoutedEventArgs e)
        {
            if (!validateInformation()) return;
            AdminScreenController.AddProduct(ProductName.Text, SupplierID.Text, CategoryID.Text, QuantityPerUnit.Text, UnitPrice.Text, UnitsInStock.Text, ReorderLevel.Text, Barcode.Text);

            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 1;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Products();
            Application.Current.Windows.OfType<AdminOparationsWindow>().FirstOrDefault().Close();
        }

        public bool validateInformation()
        {
            if (!Validate.AlphaNumeric(ProductName.Text)) { MessageBox.Show("Enter a correct Product name"); return false; }
            if (!Validate.Number(SupplierID.Text)) { MessageBox.Show("Enter a correct Supplier ID"); return false; }
            if (!Validate.Number(CategoryID.Text)) { MessageBox.Show("Enter a correct Category ID"); return false; }
            if (!Validate.AlphaNumeric(QuantityPerUnit.Text)) { MessageBox.Show("Enter a correct Quantity Per Unit"); return false; }
            if (!Validate.Money(UnitPrice.Text)) { MessageBox.Show("Enter a correct Product Price"); return false; }
            if (!Validate.Number(UnitsInStock.Text)) { MessageBox.Show("Enter a correct Units In Stock "); return false; }
            if (!Validate.Number(ReorderLevel.Text)) { MessageBox.Show("Enter a correct Re-Order Level"); return false; }
            if (!Validate.Number(Barcode.Text)) { MessageBox.Show("Enter a correct Barcode"); return false; }

            return true;
        }
    }
}
