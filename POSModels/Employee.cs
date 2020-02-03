using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class Employee
    {
        public Employee(int EmployeeID, string Firstname, string Lastname, string Title, string HomeAddress, string EmailAddress, string IDNumber, int ReportsTo, int PositionID, string Username, string Password)
        {
            this.EmployeeID = EmployeeID;
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Title = Title;
            this.HomeAddress = HomeAddress;
            this.EmailAddress = EmailAddress;
            this.IDNumber = IDNumber;
            this.ReportsTo = ReportsTo;
            this.PositionID = PositionID;
            this.Username = Username;
            this.Password = Password;
        }

        public Employee()
        {

        }
        public int EmployeeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string HomeAddress { get; set; }
        public string EmailAddress { get; set; }
        public string IDNumber { get; set; }
        public int ReportsTo { get; set; }
        public int PositionID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
