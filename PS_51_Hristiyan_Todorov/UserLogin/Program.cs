using System;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            if (LoginValidation.ValidateUserInput())
            {
                Console.WriteLine("Name: " + UserData.TestUser.Username);
                Console.WriteLine("Role: " + LoginValidation.currentUserRole);
            }
        }
    }
}
