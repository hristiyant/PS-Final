using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        private static User[] _testUsers;

        public static User[] TestUsers
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
            if(_testUsers == null)
            {
                _testUsers = new User[3];
                _testUsers[0] = new User("Test Admin", "testadmin", null, 1, DateTime.Today, DateTime.MaxValue);
                _testUsers[1] = new User("Student One", "studentone", "10101010", 4, DateTime.Today, DateTime.MaxValue);
                _testUsers[2] = new User("Student Two", "qwe123", "10101011", 4, DateTime.Today, DateTime.MaxValue);
            }
        }

        public static User IsUserPassCorrect(string username, string password)
        {
            foreach(User user in TestUsers)
            {
                if(user.Username.Equals(username) && user.Password.Equals(password))
                {
                    if(username.Length >= 5 && password.Length >= 5)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        public static void SetUserActiveTo(string username, DateTime newDate)
        {
            foreach(User user in TestUsers)
            {
                if (user.Username.Equals(username))
                {
                    user.ActiveUntil = newDate;
                    break;
                }
            }
        }

        public static void AssignUserRole(string username, UserRoles newRole)
        {
            foreach(User user in TestUsers)
            {
                if (username.Equals(username))
                {
                    user.Role = (int)newRole;
                    break;
                }
            }
        }
    }
}
