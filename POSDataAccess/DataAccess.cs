using System.Windows;

namespace POSDataAccess
{
    public class DataAccess
    {

        public static bool  CloseApplication()
        {
            var exit = MessageBox.Show("Are you sure you want to exit?", "Exit Tux?", MessageBoxButton.YesNo);

            if (exit.ToString().Equals("Yes"))
            {
                return true;
            }
            return false;
        }

    }
}
