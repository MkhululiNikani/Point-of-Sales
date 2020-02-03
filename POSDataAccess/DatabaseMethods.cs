using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using System.Windows;
using POSModels;

namespace POSDataAccess
{
    class DatabaseMethods
    {
        static string APIURL = "http://localhost/tuxshop/api/";
        public static List<Employee> SelectAllEmployees()
        {
            EmployeeResponse response = JsonConvert.DeserializeObject<EmployeeResponse>(HttpGet(APIURL+"employees/", "admin@admin.sys", "qwertyqwerty"));
            return response.data;
        }

        public static List<Product> SelectAllProducts()
        {
            ProductResponse response = JsonConvert.DeserializeObject<ProductResponse>(HttpGet(APIURL + "products/", "username", "password"));
            return response.data;
        }

        public static List<Invoice> SelectAllInvoices()
        {
            InvoiceResponse response = JsonConvert.DeserializeObject<InvoiceResponse>(HttpGet(APIURL + "invoices/", "username", "password"));
            return response.data;
        }

        public static List<Supplier> SelectAllSuppliers()
        {
            SupplierResponse response = JsonConvert.DeserializeObject<SupplierResponse>(HttpGet(APIURL + "suppliers/", "username", "password"));
            return response.data;
        }

        public static List<Category> SelectAllCategories()
        {
            CategoryResponse response = JsonConvert.DeserializeObject<CategoryResponse>(HttpGet(APIURL + "categories/", "username", "password"));
            return response.data;
        }

        public static List<TempInvoiceLine> SelectAllTempInvoiceLines()
        {
            TempInvoiceLineResponse response = JsonConvert.DeserializeObject<TempInvoiceLineResponse>(HttpGet(APIURL + "temp_invoice_items/", "username", "password"));
            return response.data;
        }

        public static List<TempInvoice> SelectAllTempInvoices()
        {
            TempInvoiceResponse response = JsonConvert.DeserializeObject<TempInvoiceResponse>(HttpGet(APIURL + "temp_invoices/", "username", "password"));
            return response.data;
        }

        public static int getLastInvoiceID(int EmployeeID)
        {
            int LastInvoiceId = 0;
            List<Invoice> invoices = SelectAllInvoices();
            foreach (Invoice currentInvoice  in invoices )
            {
                if (currentInvoice.InvoiceID > LastInvoiceId) LastInvoiceId = currentInvoice.InvoiceID;
            }
            return LastInvoiceId;
        }





        public static string HttpGet(string url, string username, string password, string body)
        {
            password = "qwertyqwerty";
            username = "admin@admin.sys";
            body = "{ \"isGET\": 1, \"api_username\": \"" + username + "\",\n \"api_password\": \"" + password + "\",\n" + body.Substring(body.IndexOf('{') + 1);
           
            var request = (HttpWebRequest)WebRequest.Create(url);


            var data = Encoding.ASCII.GetBytes(body);

            request.Method = "POST";
            request.ContentType = "application/raw";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            Console.WriteLine(url + "\n" + body);
            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
        public static string HttpGet(string url, string username, string password)
        {
            password = "qwertyqwerty";
            username = "admin@admin.sys";
            //Console.WriteLine(HttpGet(url, username, password, "{\"test\":1}"));
            return HttpGet(url, username, password, "{\"test\":1}");
           
        }

        public static string HttpPost(string url, string username, string password, string body)
        {

            password = "qwertyqwerty";
            username = "admin@admin.sys";
            body = "{ \"api_username\": \"" + username + "\",\n \"api_password\": \"" + password + "\",\n" + body.Substring(body.IndexOf('{')+1);
            Console.WriteLine(body);
            var request = (HttpWebRequest)WebRequest.Create(url);

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);

             var data = Encoding.ASCII.GetBytes(body);

            request.Method = "POST";
            request.ContentType = "application/raw";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }


            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;

        }

        public static string HttpPut(string url, string username, string password, string body)
        {

            password = "qwertyqwerty";
            username = "admin@admin.sys";
            body = "{ \"api_username\": \"" + username + "\",\n \"api_password\": \"" + password + "\",\n" + body.Substring(body.IndexOf('{') + 1);
            //MessageBox.Show(body);
            var request = (HttpWebRequest)WebRequest.Create(url);

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);

             var data = Encoding.ASCII.GetBytes(body);

            request.Method = "PUT";
            request.ContentType = "application/raw";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;

        }
        public static string HttpDelete(string url, string username, string password, string body)
        {

            password = "qwertyqwerty";
            username = "admin@admin.sys";
            body = "{ \"api_username\": \"" + username + "\",\n \"api_password\": \"" + password + "\",\n" + body.Substring(body.IndexOf('{') + 1);
            MessageBox.Show(body);
            var request = (HttpWebRequest)WebRequest.Create(url);

            String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + encoded);

            var data = Encoding.ASCII.GetBytes(body);

            request.Method = "DELETE";
            request.ContentType = "application/raw";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;

        }







        
    }
}
