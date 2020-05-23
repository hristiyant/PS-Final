using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        static private User _testUser;

        static public User TestUser
        {
            get 
            {
                ResetTestUserData();
                return _testUser;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            if(_testUser == null)
            {
                _testUser = new User("Test Admin", "qwe123", "10101010", 0);
            }
        }
    }
}
