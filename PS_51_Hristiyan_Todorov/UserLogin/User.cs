using System;

namespace UserLogin
{
    class User
    {
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
