using System;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            User testUser = new User("Admin Admin", "qwe123","10101010", 0);

            if (LoginValidation.ValidateUserInput())
            {
                Console.WriteLine(testUser.Username);
            }
        }
    }
}
