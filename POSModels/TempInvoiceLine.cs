using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class TempInvoiceLine
    {
        public TempInvoiceLine(int InvoiceID, int ProductID, int Quantity, double Price)
        {
            this.InvoiceID = InvoiceID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
            this.Price = Price;
        }

        public TempInvoiceLine()
        {

        }

        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


    }
}
