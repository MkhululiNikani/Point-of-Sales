using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;
using POSModels;

namespace POSDataAccess
{
    public class Authentication
    {
        public static bool AuthenticateCashier(string Username, string Password)
        {
            return true;
            List<Employee> Employees = DatabaseMethods.SelectAllEmployees();
            foreach(var emp in Employees)
            {
                if (Username.Equals(emp.Username) && Password.Equals(emp.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool AuthenticateAdmin(string Username, string Password)
        {
            return true;
            List<Employee> Employees = DatabaseMethods.SelectAllEmployees();
            foreach (var emp in Employees)
            {
                if (Username.Equals(emp.Username) && Password.Equals(emp.Password) && emp.PositionID == 2)
                {
                    return true;
                }
            }
            return false;
        }

        public static int SessionInfo(string Username, string Password)
        {
            List<Employee> Employees = DatabaseMethods.SelectAllEmployees();
            foreach (var emp in Employees)
            {
                if (Username.Equals(emp.Username) && Password.Equals(emp.Password))
                {
                    return emp.EmployeeID;
                }
            }
            return -1;
        }
    }
}
