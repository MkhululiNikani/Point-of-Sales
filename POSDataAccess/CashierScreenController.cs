using POSModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

namespace POSDataAccess
{
    public class CashierScreenController
    {
        static string APIURL = "http://localhost/tuxshop/api/";
        static string receiptsPath = Environment.ExpandEnvironmentVariables("%userprofile%\\Desktop\\");
        public static string GetCurrentCashierName(int EmployeeID)
        {
            return "Rick";
            List<Employee> Employees = DatabaseMethods.SelectAllEmployees();
            foreach (var emp in Employees)
            {
                if (emp.EmployeeID == EmployeeID)
                {
                    return emp.Firstname;
                }
            }
            return null;
        }
        public static DataTable AddItem(string Barcode, DataTable grid)
        {
            List<Product> Products = new List<Product>();
            Products = DatabaseMethods.SelectAllProducts();
            
            foreach (var product in Products)
            {
                if (product.Barcode.Equals(Barcode))
                {
                    
                    DataRow dr = null;
                    dr = grid.NewRow();
                    dr["ProductID"] = product.ProductID;
                    dr["UnitsInStock"] = product.UnitsInStock;
                    dr["ReOrderLevel"] = product.ReOrderLevel;
                    dr["SupplierID"] = product.SupplierID;
                    dr["CategoryID"] = product.CategoryID;
                    dr["ProductName"] = product.ProductName;
                    dr["QuantityPerUnit"] = product.QuantityPerUnit;
                    dr["Barcode"] = product.Barcode;
                    dr["Discontinued"] = product.Discontinued;
                    dr["Price"] = product.UnitPrice;
                    dr["Quantity"] = 1;
                    dr["Total"] = product.UnitPrice * Convert.ToInt32(dr["Quantity"]);

                    if (grid.Rows.Contains(dr["ProductID"]))
                    {
                        dr = grid.Rows.Find(dr["ProductID"]);
                        dr["Quantity"] = Convert.ToInt32(dr["Quantity"]) + 1;
                        dr["Total"] = product.UnitPrice * Convert.ToInt32(dr["Quantity"]);
                        return grid;
                    }

                    grid.Rows.Add(dr);
                    break;
                }
            }
            return grid;
        }

        public static bool TenderedAmountEnough(string TenderedAmount, string GrandTotal)
        {
            try
            {
                double t = Convert.ToDouble(TenderedAmount);
                double g = Convert.ToDouble(GrandTotal);
                return TenderedAmountEnough(t, g);
            }
            catch (Exception)
            {
                MessageBox.Show("Please a correct tender amount...");
                return false;
            }
            
        }
        public static bool TenderedAmountEnough(double TenderedAmount, double GrandTotal)
        {
            if(TenderedAmount < GrandTotal)
            {
                MessageBox.Show("The tendered amount is not enough.");
                return false;
            }
            return true;
        }


        public static void CreateInvoice(int EmployeeID, int CustomerID, string Date, string Time)
        {

            Invoice invoice = new Invoice(0, Date, Time, EmployeeID, CustomerID);
            string body = JsonConvert.SerializeObject(invoice);
            DatabaseMethods.HttpPost(APIURL + "invoices/", "username", "password", body);
        }
        public static void CreateInvoice(int EmployeeID, int CustomerID, DataTable grid)
        {
            
            CreateInvoice(EmployeeID, CustomerID, DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString());
            int LastInvoiceID = DatabaseMethods.getLastInvoiceID(EmployeeID);
                foreach (DataRow prod in grid.Rows)
                {
                    CreateInvoiceLine(LastInvoiceID, Convert.ToInt16(prod["ProductID"]), Convert.ToInt32(prod["Quantity"]), Double.Parse(prod["Price"].ToString()));
                    Console.WriteLine("Invoice line created");
                }

            
            PrintReciept(EmployeeID, CustomerID, LastInvoiceID, grid);
        }

        

        public static void CreateInvoiceLine(int InvoiceID, int ProductID, int Quantity, double Price)
        {
            InvoiceLine invoiceLine = new InvoiceLine(InvoiceID, ProductID, Quantity, Price);
            string body = JsonConvert.SerializeObject(invoiceLine);
            DatabaseMethods.HttpPost(APIURL + "invoice_items/ ", "username", "password", body);
        }

       
        public static void CheckStockLevels(DataTable grid)
        {
            foreach (DataRow data in grid.Rows)
            {
                if ((Convert.ToInt32(data["UnitsInStock"]) - Convert.ToInt32(data["Quantity"])) < Convert.ToInt32(data["ReOrderLevel"]) )
                {
                    SendOrderEmail(Convert.ToInt32(data["SupplierID"]), data["ProductName"].ToString());
                }
            }
        }

        public static void SendOrderEmail(int SupplierID, string Product)
        {
            List<Supplier> Suppliers = DatabaseMethods.SelectAllSuppliers();

            foreach (Supplier CurrentSupplier in Suppliers)
            {
                if(SupplierID == CurrentSupplier.SupplierID)
                {
                    SendOrderEmail(CurrentSupplier.Email, Product);
                }
            }
        }
        

        public static void UpdateStock(DataTable grid)
        {
            
            foreach (DataRow dr in grid.Rows)
            {
                Product product = new Product(Convert.ToInt16(dr["ProductID"].ToString()),
                                                    dr["ProductName"].ToString(),
                                                    Convert.ToInt16(dr["SupplierID"].ToString()),
                                                    Convert.ToInt16(dr["CategoryID"].ToString()),
                                                    dr["QuantityPerUnit"].ToString(),
                                                    Convert.ToDouble(dr["Price"].ToString()),
                                                    Convert.ToInt16(dr["UnitsInStock"].ToString()) - Convert.ToInt16(dr["Quantity"].ToString()),
                                                    Convert.ToInt16(dr["ReorderLevel"].ToString()),
                                                    dr["Barcode"].ToString(),
                                                    0);
                string body = JsonConvert.SerializeObject(product);
                DatabaseMethods.HttpPut(APIURL + "products/", "username", "password", body);
                
            }
        }



        public static DataTable UsePicknScan(int invoiceID, DataTable grid)
        {
            





            //GET INFORMATION FROM THE TEMP INVOICE
            //AND POPULATE grid WITH IT ACCORDINGLY

            List<TempInvoiceLine> TempInvoiceLines = new List<TempInvoiceLine>();
            TempInvoiceLines = DatabaseMethods.SelectAllTempInvoiceLines();
            List<Product> Products = DatabaseMethods.SelectAllProducts();
            foreach (var invoiceLine in TempInvoiceLines)
            {
                if (invoiceLine.InvoiceID == invoiceID)
                {
                    foreach (var product in Products)
                    {
                        if (product.ProductID == invoiceLine.ProductID)
                        {

                            DataRow dr = null;
                            dr = grid.NewRow();
                            dr["ProductID"] = product.ProductID;
                            dr["UnitsInStock"] = product.UnitsInStock;
                            dr["ReOrderLevel"] = product.ReOrderLevel;
                            dr["SupplierID"] = product.SupplierID;
                            dr["CategoryID"] = product.CategoryID;
                            dr["ProductName"] = product.ProductName;
                            dr["QuantityPerUnit"] = product.QuantityPerUnit;
                            dr["Barcode"] = product.Barcode;
                            dr["Discontinued"] = product.Discontinued;
                            dr["Price"] = product.UnitPrice;
                            dr["Quantity"] = invoiceLine.Quantity;
                            dr["Total"] = product.UnitPrice * Convert.ToInt32(dr["Quantity"]);

                            grid.Rows.Add(dr);
                            break;
                        }
                    }
                }
            }
            return grid;
        }


        public static int getCustomerID(int invoiceID)
        {
            //FIRST GET THE CUSTOMER_ID FROM TEMP_INVOICE
            List<TempInvoice> TempInvoices = new List<TempInvoice>();
            TempInvoices = DatabaseMethods.SelectAllTempInvoices();

            foreach (var tempInvoice in TempInvoices)
            {
                if (tempInvoice.InvoiceID == invoiceID)
                {
                    return tempInvoice.CustomerID;
                }

            }

            return 00;
        }






















        // TO BE CODED
        public static void SendOrderEmail(string emailAddress, string product)
        {
            return;
            Console.WriteLine("Email Invoked for " + product + " to " + emailAddress);
            string EmailSubject = "Stock Order for " + product;
            string EmailBody = "Hey\n" +
                                "It's the manager of The Tux Shop at MUT\n" +
                                "We are running out of "+ product +
                                "\nWe need stock and we need it fast\n" +
                                "Okay Thanx Bye";
            MailMessage mail = new MailMessage("mkhululinikani@gmail.com", emailAddress, EmailSubject, EmailBody);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential()
            {
                UserName = "email@example.com",
                Password = "yourpassword"
            };
            smtpClient.EnableSsl = true;
            {
                smtpClient.Send(mail);
            }
        }

        public static void PrintReciept(int EmployeeID, int CustomerID, int invoiceID, DataTable grid)
        {

            Document receipt = new Document(PageSize.A5);
            PdfWriter pdfWriter = PdfWriter.GetInstance(receipt, new FileStream(receiptsPath + "reciept_" + invoiceID + ".pdf", FileMode.Create));
            receipt.Open();
            Paragraph paragraph = new Paragraph("The Tux Shop\n\n\n");
            receipt.Add(paragraph);

            string date = DateTime.Now.ToShortDateString();
            string time = DateTime.Now.ToShortTimeString();
            string dateTime = "Date \t: " + date + "   -   " +time + "\n\n";
            string recieptInfo = dateTime;

            foreach(DataRow row in grid.Rows)
            {
                recieptInfo = recieptInfo + row["ProductName"].ToString() + "                                  -  x" 
                    + row["Quantity"].ToString() + "              R" + row["Total"].ToString() + "\n";
            }
            

            paragraph = new Paragraph(recieptInfo);

            receipt.Add(paragraph);
            receipt.Close();
            Console.WriteLine("Reciept Printed");
        }

    }
}
