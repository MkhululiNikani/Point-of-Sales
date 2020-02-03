using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class InvoiceLine
    {
        public InvoiceLine(int InvoiceID, int ProductID, int Quantity, double Price)
        {
            this.InvoiceID = InvoiceID;
            this.ProductID = ProductID;
            this.Quantity = Quantity;
            this.Price = Price;
        }

        public InvoiceLine()
        {

        }

        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
