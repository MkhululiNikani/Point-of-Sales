using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace POSDataAccess
{
    public class Validate
    {
        public static bool Name(string str)
        {
            Regex regex = new Regex(@"^(?=.{1,40}$)[a-zA-Z]+(?:[-'\s][a-zA-Z]+)*$");
            return regex.IsMatch(str);
        }

        public static bool Email(string str)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(str);
            
        }

        public static bool Phone(string str)
        {
            Regex regex = new Regex(@"^0[0-9]{9}$");
            return regex.IsMatch(str);
        }

        public static bool IDNumber(string str)
        {
            Regex regex = new Regex(@"^[0-9]{13}$");
            return regex.IsMatch(str);
        }

        public static bool PostalCode(string str)
        {
            Regex regex = new Regex(@"^[0-9]{4}$");
            return regex.IsMatch(str);
        }

        public static bool Money(string str)
        {
            Regex regex = new Regex(@"^\d+(?:\.\d{2})?$");
            return regex.IsMatch(str);
        }

        public static bool Barcode(string str)
        {
            Regex regex = new Regex(@"^\d+$");
            return true;
        }

        public static bool Number(string str)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(str);
        }

        public static bool AlphaNumeric(string str)
        {
            Regex regex = new Regex(@"^[a-zA-Z\d\-_\s]+$");
            return regex.IsMatch(str);
        }
    }
}
