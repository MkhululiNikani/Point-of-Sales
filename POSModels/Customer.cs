using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class Customer
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string HomeAddress { get; set; }
        public string EmailAddress { get; set; }
        public long MobileNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int EmployeePositionID { get; set; }

        
    }
}
