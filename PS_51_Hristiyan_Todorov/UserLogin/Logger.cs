using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class Logger
    {
        private const string LOG_FILE_PATH = @".\TEST_LOG_FILE.txt";
        private static List<string> CurrentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + "; "
                + LoginValidation.LoggedUser.Username + "; "
                + UserRolesExtensions.ToFriendlyString((UserRoles)LoginValidation.LoggedUser.Role) + "; "
                + activity + "\n";

            if (File.Exists(LOG_FILE_PATH))
            {
                File.AppendAllText(LOG_FILE_PATH, activityLine);
            }
            else
            {
                StreamWriter file = new StreamWriter(LOG_FILE_PATH);
                file.WriteLine(activityLine);
                file.Close();
            }

            CurrentSessionActivities.Add(activityLine);
        }

        public static void GetLoggedActivity()
        {
            try
            {
                string LogContent = File.ReadAllText(LOG_FILE_PATH);
                Console.WriteLine(LogContent);
            }
            catch (FileNotFoundException e)
            {
                /*if (e.Source != null)
                {
                    Console.WriteLine("IOException source: {0}", e.Source);
                }*/
                Console.WriteLine("Посоченият файл не съществува.");
            }
        }

        public static void GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("*** Текуща активност: \n");

            foreach (String line in CurrentSessionActivities)
            {
                sb.Append(line + "\n");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
