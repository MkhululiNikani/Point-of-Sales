using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class TempInvoice
    {
        public TempInvoice(int InvoiceID, string InvoiceDate, string InvoiceTime, int CustomerID)
        {
            this.InvoiceID = InvoiceID;
            this.InvoiceDate = InvoiceDate;
            this.InvoiceTime = InvoiceTime;
            this.CustomerID = CustomerID;
        }

        public TempInvoice()
        {

        }
        public int InvoiceID { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceTime { get; set; }
        public int CustomerID { get; set; }
    }
}

