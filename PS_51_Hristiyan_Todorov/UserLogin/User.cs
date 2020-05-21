using System;

namespace UserLogin
{
    class User
    {
        /*private String Username;
        private String Password;
        private String FakNum;
        private Int32 Role;*/

        public string Username { get; set; }
        public string Password { get; set; }
        public string FakNum { get; set; }
        public int Role { get; set; }

        public User(string username, string password, string fakNum, int role)
        {
            Username = username;
            Password = password;
            FakNum = fakNum;
            Role = role;
        }
    }
}
