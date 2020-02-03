using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class Product
    {
        public Product(int ProductID, string ProductName, int SupplierID, int CategoryID, string QuantityPerUnit, double UnitPrice, int UnitsInStock, int ReOrderLevel, string Barcode, int Discontinued)
        {
            this.ProductID = ProductID;
            this.ProductName = ProductName;
            this.SupplierID = SupplierID;
            this.CategoryID = CategoryID;
            this.QuantityPerUnit = QuantityPerUnit;
            this.UnitPrice = UnitPrice;
            this.UnitsInStock = UnitsInStock;
            this.ReOrderLevel = ReOrderLevel;
            this.Barcode = Barcode;
            this.Discontinued = Discontinued;
        }

        public Product()
        {

        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int ReOrderLevel { get; set; }
        public string Barcode { get; set; }
        public int Discontinued { get; set; }

    }
}
