using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    static class UserData
    {
        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUsersData();
                return _testUsers;
            }
            set { }
        }

        private static void ResetTestUsersData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>(3);
                _testUsers.Add(new User("Test Admin", "testadmin", null, 2, DateTime.Today, DateTime.MaxValue));
                _testUsers.Add(new User("Student One", "studentone", "10101010", 5, DateTime.Today, DateTime.MaxValue));
                _testUsers.Add(new User("Student Two", "qwe123", "10101011", 5, DateTime.Today, DateTime.MaxValue));
            }
        }

        //Not used.
        //Checks if a user with the specified name currently exists.
        public static bool IsUserExisting(string name)
        {
            foreach (User user in TestUsers)
            {
                if (user.Username.Equals(name))
                {
                    return true;
                }
            }

            return false;
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            UserContext context = new UserContext();

            User result = (
                from user in context.Users
                where (user.Username.Equals(username) && user.Password.Equals(password))
                select user
                ).First();

            if (username.Length >= 5 && password.Length >= 5)
            {
                return result;
            }

            return null;
        }

        public static void AssignUserRole(string username, UserRoles newRole)
        {
            UserContext userContext = new UserContext();
            LoggerContext loggerContext = new LoggerContext();

            User user = (
                from u in userContext.Users
                where u.Username.Equals(username)
                select u
                ).First();

            user.Role = (int)newRole;
            userContext.SaveChanges();

            loggerContext.Logs.Add(new Logs("Промяна на роля на " + username));
            loggerContext.SaveChanges();
            Logger.LogActivity("Промяна на роля на " + username);
            MyCustomLogger.Logger.LogActivity("Промяна на роля на " + username);

            /*Old implementation:
            foreach (User user in TestUsers)
            {
                if (user.Username.Equals(username))
                {
                    string oldValue = UserRolesExtensions.ToFriendlyString((UserRoles)user.Role);
                    user.Role = (int)newRole;
                    string newValue = UserRolesExtensions.ToFriendlyString((UserRoles)user.Role);
                    Logger.LogActivity("Промяна на роля на " + username);
                    Console.WriteLine("Успешно сменихте ролята от " + oldValue + " на " + newValue + ".");
                    break;
                }
            }*/
        }

        public static void AssignUserActiveTo(string username, DateTime newDate)
        {
            UserContext userContext = new UserContext();
            LoggerContext loggerContext = new LoggerContext();

            User user = (
                from u in userContext.Users
                where u.Username.Equals(username)
                select u
                ).First();

            user.ActiveUntil = newDate;
            userContext.SaveChanges();

            loggerContext.Logs.Add(new Logs("Промяна на активност на " + username));
            loggerContext.SaveChanges();
            Logger.LogActivity("Промяна на активност на " + username);
            MyCustomLogger.Logger.LogActivity("Промяна на активност на " + username);

            /*Old implementation:
            foreach (User user in TestUsers)
            {
                if (user.Username.Equals(username))
                {
                    string oldValue = user.ActiveUntil.ToString();
                    user.ActiveUntil = activeUntil;
                    string newValue = user.ActiveUntil.ToString();
                    Logger.LogActivity("Промяна на активност на " + username);
                    Console.WriteLine("Успешно сменихте активност от " + oldValue + " на " + newValue + ".");
                    break;
                }
            }*/
        }

        public static void PrintAllUsersList()
        {

        }
    }
}
