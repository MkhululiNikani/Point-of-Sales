using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class Invoice
    {
        public Invoice(int InvoiceID, string InvoiceDate, string InvoiceTime, int EmployeeID, int CustomerID)
        {
            this.InvoiceID = InvoiceID;
            this.InvoiceDate = InvoiceDate;
            this.InvoiceTime = InvoiceTime;
            this.EmployeeID = EmployeeID;
            this.CustomerID = CustomerID;
        }

        public Invoice()
        {

        }
        public int InvoiceID { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceTime { get; set; }
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; }
    }
}
