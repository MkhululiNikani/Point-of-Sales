using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSModels
{
    public class Supplier
    {
        public Supplier(int SupplierID, string CompanyName, string PhysicalAddress, string City, string Region, int PostalCode, string Country, string Phone, string EmailAddress)
        {
            this.SupplierID = SupplierID;
            this.CompanyName = CompanyName;
            this.Address = PhysicalAddress;
            this.City = City;
            this.Region = Region;
            this.PostalCode = PostalCode;
            this.Country = Country;
            this.Phone = Phone;
            this.Email = EmailAddress;
        }

        public Supplier()
        {

        }

        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
