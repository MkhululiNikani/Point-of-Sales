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
using System.Windows.Shapes;

namespace Tux.Cashier
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        private void OK_PicknScan(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(PicknScanCode.Text, out int x))
            {
                PicknScanCode.Text = "";
                return;
            }
            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().IsEnabled = true;
            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().Opacity = 1;
            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().ShowInTaskbar = true;
            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().PicknScanCode = PicknScanCode.Text;
            Application.Current.Windows.OfType<DialogWindow>().FirstOrDefault().Close();
        }

        private void CloseApp(object sender, MouseButtonEventArgs e)
        {
            PicknScanCode.Text = "0";
            OK_PicknScan(sender, e);
        }
    }
}
