using System;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using POSModels;
using System.Collections.Generic;

namespace POSDataAccess
{
    public class AdminScreenController
    {

        static string APIURL = "http://mkhululi.net/picknscan/api/";
        //static string APIURL = "http://localhost/picknscan/api/";
        public static DataTable LoadAllProducts()
        {
            DataTable dataTable = new DataTable();
            List<Product> Products = DatabaseMethods.SelectAllProducts();
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("UnitsInStock", typeof(int));
            dataTable.Columns.Add("ReOrderLevel", typeof(int));
            dataTable.Columns.Add("SupplierID", typeof(int));
            dataTable.Columns.Add("ProductName", typeof(string));
            dataTable.Columns.Add("QuantityPerUnit", typeof(string));
            dataTable.Columns.Add("CategoryID", typeof(int));
            dataTable.Columns.Add("UnitPrice", typeof(double));
            dataTable.Columns.Add("Barcode", typeof(string));
            dataTable.Columns.Add("Discontinued", typeof(int));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["ProductID"] };
            foreach (var product in Products)
            {
                    DataRow dr = null;
                    dr = dataTable.NewRow();
                    dr["ProductID"] = product.ProductID;
                    dr["UnitsInStock"] = product.UnitsInStock;
                    dr["ReOrderLevel"] = product.ReOrderLevel;
                    dr["SupplierID"] = product.SupplierID;
                    dr["ProductName"] = product.ProductName;
                    dr["CategoryID"] = product.CategoryID;
                    dr["QuantityPerUnit"] = product.QuantityPerUnit;
                    dr["Discontinued"] = product.Discontinued;
                    dr["UnitPrice"] = product.UnitPrice;
                    dr["Barcode"] = product.Barcode;
                    dataTable.Rows.Add(dr);
                
            }
            return dataTable;
        }

        public static DataTable LoadAllCategories()
        {
            DataTable dataTable = new DataTable();
            List<Category> Categories = DatabaseMethods.SelectAllCategories();
            dataTable.Columns.Add("CategoryID", typeof(int));
            dataTable.Columns.Add("CategoryName", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["CategoryID"] };
            foreach (Category category in Categories)
            {
                DataRow dr = null;
                dr = dataTable.NewRow();
                dr["CategoryID"] = category.CategoryID;
                dr["CategoryName"] = category.CategoryName;
                dr["Description"] = category.Description;
                dataTable.Rows.Add(dr);

            }
            return dataTable;
        }

        public static DataTable LoadAllEmployees()
        {
            DataTable dataTable = new DataTable();
            List<Employee> Employees = DatabaseMethods.SelectAllEmployees();
            dataTable.Columns.Add("EmployeeID", typeof(int));
            dataTable.Columns.Add("Firstname", typeof(string));
            dataTable.Columns.Add("Lastname", typeof(string));
            dataTable.Columns.Add("Title", typeof(string));
            dataTable.Columns.Add("HomeAddress", typeof(string));
            dataTable.Columns.Add("EmailAddress", typeof(string));
            dataTable.Columns.Add("IDNumber", typeof(string));
            dataTable.Columns.Add("PositionID", typeof(int));
            dataTable.Columns.Add("ReportsTo", typeof(int));
            dataTable.Columns.Add("Username", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["EmployeeD"] };
            foreach (Employee employee in Employees)
            {
                DataRow dr = null;
                dr = dataTable.NewRow();
                dr["EmployeeID"] = employee.EmployeeID;
                dr["Firstname"] = employee.Firstname;
                dr["Lastname"] = employee.Lastname;
                dr["Title"] = employee.Title;
                dr["HomeAddress"] = employee.HomeAddress;
                dr["EmailAddress"] = employee.EmailAddress;
                dr["IDNumber"] = employee.IDNumber;
                dr["PositionID"] = employee.PositionID;
                dr["ReportsTo"] = employee.ReportsTo;
                dr["Username"] = employee.Username;
                dr["Password"] = employee.Password;
                dataTable.Rows.Add(dr);

            }

            return dataTable;
        }

        public static DataTable LoadAllSuppliers()
        {
            DataTable dataTable = new DataTable();
            List<Supplier> Suppliers = DatabaseMethods.SelectAllSuppliers();
            dataTable.Columns.Add("SupplierID", typeof(int));
            dataTable.Columns.Add("CompanyName", typeof(string));
            dataTable.Columns.Add("PhysicalAddress", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("Region", typeof(string));
            dataTable.Columns.Add("PostalCode", typeof(int));
            dataTable.Columns.Add("Country", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("EmailAddress", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns["SupplierID"] };
            foreach (Supplier supplier in Suppliers)
            {
                DataRow dr = null;
                dr = dataTable.NewRow();
                dr["SupplierID"] = supplier.SupplierID;
                dr["CompanyName"] = supplier.CompanyName;
                dr["PhysicalAddress"] = supplier.Address;
                dr["City"] = supplier.City;
                dr["Region"] = supplier.Region;
                dr["PostalCode"] = supplier.PostalCode;
                dr["Country"] = supplier.Country;
                dr["Phone"] = supplier.Phone;
                dr["EmailAddress"] = supplier.Email;
                dataTable.Rows.Add(dr);

            }

            return dataTable;
        
        }

        public static void AddCategory(string name, string description)
        {
            Category category = new Category(0, name, description);
            string body = JsonConvert.SerializeObject(category);
            DatabaseMethods.HttpPost(APIURL + "categories/", "username", "password", body);
        }
        
        public static void AddSupplier(string CompanyName, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Email)
        {
            Supplier supplier = new Supplier(0, CompanyName, Address, City, Region, Convert.ToInt16(PostalCode), Country, Phone, Email);            
            string body = JsonConvert.SerializeObject(supplier);
            DatabaseMethods.HttpPost(APIURL+"suppliers/", "username", "password", body);
        }

        public static void AddProduct(string ProductName, string SupplierID, string CategoryID, string QuantityPerUnit, string UnitPrice, string UnitsInStock, string ReOrderLevel, string Barcode)
        {
            Product product = new Product(0,
                                          ProductName,
                                          Convert.ToInt16(SupplierID),
                                          Convert.ToInt16(CategoryID),
                                          QuantityPerUnit,
                                          Convert.ToDouble(UnitPrice.Replace('.',',')),
                                          Convert.ToInt16(UnitsInStock),
                                          Convert.ToInt16(ReOrderLevel),
                                          Barcode, 0);


            string body = JsonConvert.SerializeObject(product);
            Console.WriteLine(body);
            DatabaseMethods.HttpPost(APIURL + "products/", "username", "password", body);
        }

        public static void AddEmployee(string LastName, string FirstName, string Title, string IDNO, string Address, string ReportsTo, string Email, string PositionID, string Username, string Password)
        {
            Employee employee = new Employee(0, FirstName, LastName, Title, Address, Email, IDNO, Convert.ToInt16(ReportsTo), Convert.ToInt16(PositionID), Username, Password);
            string body = JsonConvert.SerializeObject(employee);
            DatabaseMethods.HttpPost(APIURL + "employees/", "username", "password", body);
        }

        public static void UpdateAllCategories(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                Category category = new Category(Convert.ToInt16(dr["CategoryID"].ToString()),
                                                 dr["CategoryName"].ToString(),
                                                 dr["Description"].ToString());
                string body = JsonConvert.SerializeObject(category);
                DatabaseMethods.HttpPut(APIURL + "categories/", "username", "password", body);
            }
        }
        public static void UpdateAllSuppliers(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                Supplier supplier = new Supplier(Convert.ToInt16(dr["SupplierID"].ToString()),
                                                 dr["CompanyName"].ToString(),
                                                 dr["PhysicalAddress"].ToString(),
                                                 dr["City"].ToString(),
                                                 dr["Region"].ToString(),
                                                 Convert.ToInt16(dr["PostalCode"].ToString()),
                                                 dr["Country"].ToString(),
                                                 dr["Phone"].ToString(),
                                                 dr["EmailAddress"].ToString());
                string body = JsonConvert.SerializeObject(supplier);
                DatabaseMethods.HttpPut(APIURL + "suppliers/", "username", "password", body);
            }
        }
        public static void UpdateAllProducts(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
               Product product = new Product(Convert.ToInt16(dr["ProductID"].ToString()),
                                                dr["ProductName"].ToString(),
                                                Convert.ToInt16(dr["SupplierID"].ToString()),
                                                Convert.ToInt16(dr["CategoryID"].ToString()),
                                                dr["QuantityPerUnit"].ToString(),
                                                Convert.ToDouble(dr["UnitPrice"].ToString().Replace('.', ',')),
                                                Convert.ToInt16(dr["UnitsInStock"].ToString()),
                                                Convert.ToInt16(dr["ReorderLevel"].ToString()),
                                                dr["Barcode"].ToString(),
                                                0);

                string body = JsonConvert.SerializeObject(product);

                Console.WriteLine("--------------------------------------------------------------------------------------");
                Console.WriteLine(body);
                Console.WriteLine("--------------------------------------------------------------------------------------");

                DatabaseMethods.HttpPut(APIURL + "products/", "username", "password", body);
            }
        }
        public static void UpdateAllEmployees(DataTable dataTable)
        {
            foreach (DataRow dr in dataTable.Rows)
            {
                
                Employee employee = new Employee(Convert.ToInt16(dr["EmployeeID"].ToString()),
                                                 dr["FirstName"].ToString(),
                                                 dr["LastName"].ToString(),
                                                 dr["Title"].ToString(),
                                                 dr["HomeAddress"].ToString(),
                                                 dr["EmailAddress"].ToString(),
                                                 dr["IDNumber"].ToString(),
                                                 Convert.ToInt16(dr["ReportsTo"].ToString()),
                                                 Convert.ToInt16(dr["PositionID"].ToString()),
                                                 dr["Username"].ToString(),
                                                 dr["Password"].ToString());
                string body = JsonConvert.SerializeObject(employee);
                DatabaseMethods.HttpPut(APIURL + "employees/", "username", "password", body);
            }
        }

    }

}
