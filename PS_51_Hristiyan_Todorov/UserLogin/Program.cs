using System;
using System.IO;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            //Set Console's Encoding to support cyrillic symbols.
            Console.OutputEncoding = Encoding.UTF8;

            /*Only called once to fill db
            CopyTestUsers();*/

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
                    GetAdminChoice();
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
                "2: Промяна на активност на потребител\n" +
                "3: Списък на потребителите\n" +
                "4: Преглед на лог на активност\n" +
                "5: Преглед на текущата активност"
                );
        }

        private static void GetAdminChoice()
        {
            string selection;
            try
            {
                selection = Console.ReadLine();

                switch (selection)
                {
                    case "0":
                        Environment.Exit(1);        //Exit console app
                        break;
                    case "1":
                        InitiateAssignUserRole();
                        break;
                    case "2":
                        InitiateSetUserActiveTo();
                        break;
                    case "3":
                        UserData.PrintAllUsersList();
                        break;
                    case "4":
                        Logger.GetLoggedActivity();
                        break;
                    case "5":
                        Logger.GetCurrentSessionActivities();
                        break;
                }
                
            }
            catch (IOException e)
            {
                Console.WriteLine("Нещо се обърка! :(\n Опитайте отново по-късно.");
            }
        }

        private static void InitiateAssignUserRole()
        {
            Console.WriteLine("Моля въведете име на желания потребител: ");
            string name = Console.ReadLine();
            //TODO: check if user with that name exists and if true:
            Console.WriteLine(
                "Моля въведете стойност за новата роля: \n" +
                "1: ANONYMOUS\n" +
                "2: ADMIN\n" +
                "3: INSPECTOR\n" +
                "4: PROFESSOR\n" +
                "5: STUDENT\n");

            string selection = Console.ReadLine();
            UserRoles newRole = UserRoles.NONE;
            switch (selection)
            {
                case "1":
                    newRole = UserRoles.ANONYMOUS;
                    break;
                case "2":
                    newRole = UserRoles.ADMIN;
                    break;
                case "3":
                    newRole = UserRoles.INSPECTOR;
                    break;
                case "4":
                    newRole = UserRoles.PROFESSOR;
                    break;
                case "5":
                    newRole = UserRoles.STUDENT;
                    break;
            }

            UserData.AssignUserRole(name, newRole);
        }

        private static void InitiateSetUserActiveTo()
        {
            Console.WriteLine("Моля въведете име на желания потребител: ");
            string name = Console.ReadLine();
            //TODO: Check if user exists
            Console.WriteLine("Моля въведете нова стойност за активност: ");
            string newActiveUntilValue = Console.ReadLine();

            UserData.AssignUserActiveTo(name, DateTime.Parse(newActiveUntilValue));
        }

        private static void CopyTestUsers()
        {
            UserContext context = new UserContext();
            foreach(User user in UserData.TestUsers)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
