using System;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set Console's Encoding to support cyrillic symbols.
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Въведете потребителско име: ");
            string Username = Console.ReadLine();
            Console.WriteLine("Въведете парола: ");
            string Password = Console.ReadLine();

            User currentUser = new User(Username, Password);

            LoginValidation loginValidation = new LoginValidation(Username, Password, PrintErrorMessage);

            if (loginValidation.ValidateUserInput(currentUser))
            {
                PrintUserInfo();

                if (LoginValidation.CurrentUserRole.Equals(UserRoles.ADMIN))
                {
                    PrintAdminMenu();
                }
            }
        }

        private static void PrintUserInfo()
        {
            switch (LoginValidation.CurrentUserRole)
            {
                case UserRoles.ANONYMOUS:
                    Console.WriteLine("Current user role is: ANONYMOUS");
                    break;
                case UserRoles.ADMIN:
                    Console.WriteLine("Current user role is: ADMIN");
                    break;
                case UserRoles.INSPECTOR:
                    Console.WriteLine("Current user role is: INSPECTOR");
                    break;
                case UserRoles.PROFESSOR:
                    Console.WriteLine("Current user role is: PROFESSOR");
                    break;
                case UserRoles.STUDENT:
                    Console.WriteLine("Current user role is: STUDENT");
                    break;
            }

            Console.WriteLine("Активен до: " + LoginValidation.LoggedUser.ActiveUntil);
        }

        private static void PrintErrorMessage(string errorMessage)
        {
            Console.WriteLine("!!! " + errorMessage + " !!!");
        }

        private static void PrintAdminMenu()
        {
            Console.WriteLine(
                "Изберете опция: \n" +
                "0: Изход\n" +
                "1: Промяна на роля на потребител\n" +
                "2: Промяна на активност на потребител"
                );
        }
    }
}
