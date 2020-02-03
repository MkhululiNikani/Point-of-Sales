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
using System.Windows.Threading;
using System.Data;
using POSDataAccess;
using Tux.Cashier;

namespace Tux
{
    /// <summary>
    /// </summary>
    public partial class CashierWindow : Window
    {
        DataTable grid = new DataTable();
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
        public string PicknScanCode { get; set; }
        public CashierWindow()
        {
            InitializeComponent();
            Init();

        }
        

        private void Close(object sender, MouseEventArgs e)
        {
            if(!POSDataAccess.DataAccess.CloseApplication()) return;
            Application.Current.Shutdown();
        }
        private void Minimize(object sender, MouseEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Logout(object sender, MouseButtonEventArgs e)
        {
            Welcome welcomeScreen = new Welcome();
            welcomeScreen.Show();
            Window.GetWindow(this).Close();
        }
        

        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            grid = CashierScreenController.AddItem(Barcode.Text, grid);
            ItemsDataGrid.ItemsSource = grid.DefaultView;
            calculateSubTotal();
            //calculateVAT();
            calculateGrandTotal();
        }
        private void PayButtonClick(object sender, RoutedEventArgs e)
        {
            if (!calculateChange()) return;
            CashierScreenController.UpdateStock(grid);
            CashierScreenController.CreateInvoice(EmployeeID, CustomerID, grid);
            CashierScreenController.CheckStockLevels(grid);

            // Next Customer Please 
            CashierWindow cashierReloaded = new CashierWindow();
            cashierReloaded.EmployeeID = EmployeeID;
            MessageBox.Show("Next Customer");
            cashierReloaded.Show();
            this.Close();
        }


        private void UsePicknScan(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("This will be calling a fucntion for PicknScan");
            DialogWindow PicknScanDialog = new DialogWindow();
            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().IsEnabled = false;
            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().Opacity = 0.8;
            Application.Current.Windows.OfType<CashierWindow>().FirstOrDefault().ShowInTaskbar = true;
            PicknScanDialog.Show();
        }





















































        private void Init()
        {
            CustomerID = 0;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            timer.Start();

            DataColumn ItemNumber = new DataColumn();
            ItemNumber.ColumnName = "ItemNumber";
            ItemNumber.DataType = Type.GetType("System.Int32");
            ItemNumber.AutoIncrement = true;
            ItemNumber.AutoIncrementSeed = 1;
            ItemNumber.AutoIncrementStep = 1;
            ItemNumber.ReadOnly = true;
            ItemNumber.Unique = true;
            grid.Columns.Add(ItemNumber);
            grid.Columns.Add("ProductID", typeof(int));
            grid.Columns.Add("UnitsInStock", typeof(int));
            grid.Columns.Add("ReOrderLevel", typeof(int));
            grid.Columns.Add("SupplierID", typeof(int));
            grid.Columns.Add("CategoryID", typeof(int));
            grid.Columns.Add("QuantityPerUnit", typeof(string));
            grid.Columns.Add("ProductName", typeof(string));
            grid.Columns.Add("Price", typeof(double));
            grid.Columns.Add("Quantity", typeof(int));
            grid.Columns.Add("Barcode", typeof(string));
            grid.Columns.Add("Discontinued", typeof(int));
            grid.Columns.Add("Total", typeof(double));
            grid.PrimaryKey = new DataColumn[] { grid.Columns["ProductID"] };

        }
        void TimerTick(object sender, EventArgs e)
        {
            TimeTextBlock.Text = DateTime.Now.ToShortTimeString();
        }
        private void calculateSubTotal()
        {
            double sum = 0;
            foreach(DataRow product in grid.Rows)
            {
                sum += Convert.ToDouble(product["Total"]);
            }
            SubTotal.Text = sum.ToString("F");
            //Rubbish
            calculateVAT();
            SubTotal.Text = (sum - Convert.ToDouble(VAT.Text)).ToString("F");
        }
        private void calculateVAT()
        {
            VAT.Text = (Convert.ToDouble(SubTotal.Text)*0.15).ToString("F");
        }
        private void calculateGrandTotal()
        {
            GrandTotal.Text = (Convert.ToDouble(SubTotal.Text) + Convert.ToDouble(VAT.Text)).ToString("F");
        }
        private bool calculateChange()
        {
            if (!CashierScreenController.TenderedAmountEnough(TenderedAmount.Text, GrandTotal.Text))
            {
                TenderedAmount.Text = "";
                return false;
            }
            Change.Text = (Convert.ToDouble(TenderedAmount.Text) - Convert.ToDouble(GrandTotal.Text)).ToString();
            return true;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.CashierName.Text =  CashierScreenController.GetCurrentCashierName(EmployeeID);

        }

    }
}
