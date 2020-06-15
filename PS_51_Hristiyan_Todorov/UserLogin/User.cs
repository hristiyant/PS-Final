using System;

namespace UserLogin
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FakNum { get; set; }
        public int Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime ActiveUntil { get; set; }

        public User(string username, string password, string fakNum, int role, DateTime created, DateTime activeUntil)
        {
            Username = username;
            Password = password;
            FakNum = fakNum;
            Role = role;
            Created = created;
            ActiveUntil = activeUntil;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
