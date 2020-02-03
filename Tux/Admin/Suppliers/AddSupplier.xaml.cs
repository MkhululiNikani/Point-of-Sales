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
    /// Interaction logic for AddSupplier.xaml
    /// </summary>
    public partial class AddSupplier : Page
    {
        public AddSupplier()
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

        private void AddSupplierToDatabase(object sender, RoutedEventArgs e)
        {
            if(!validateInformation()) return;
            AdminScreenController.AddSupplier(CompanyName.Text, Address.Text, City.Text, Region.Text, PostalCode.Text, Country.Text, Phone.Text, Email.Text);

            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().IsEnabled = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().Opacity = 1;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().ShowInTaskbar = true;
            Application.Current.Windows.OfType<AdminWindows>().FirstOrDefault().MainFrame.Content = new Suppliers();
            Application.Current.Windows.OfType<AdminOparationsWindow>().FirstOrDefault().Close();
        }



        
        public bool validateInformation()
        {
            if (!Validate.AlphaNumeric(CompanyName.Text)) { MessageBox.Show("Enter a correct company name"); return false; }
            if (!Validate.AlphaNumeric(Address.Text)) { MessageBox.Show("Enter a correct address"); return false; }
            if (!Validate.Name(City.Text)) { MessageBox.Show("Enter a correct city name"); return false; }
            if (!Validate.Name(Region.Text)){ MessageBox.Show("Enter a correct region name"); return false; }
            if (!Validate.PostalCode(PostalCode.Text)){ MessageBox.Show("Enter a correct postal code"); return false;}
            if (!Validate.Name(Country.Text)){ MessageBox.Show("Enter a correct country"); return false;}
            if (!Validate.Phone(Phone.Text)){ MessageBox.Show("Enter a correct Phone Number"); return false;}
            if (!Validate.Email(Email.Text)){ MessageBox.Show("Enter a correct email address"); return false;}

            return true;
        }

    }
}
