using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        public static User LoggedUser;
        public delegate void ActionOnError(string ErrorMessage);
        private ActionOnError _actionOnError;
        private string Username { get; set; }
        private string Password { get; set; }
        private string ErrorMessage { get; set; }
        public static UserRoles CurrentUserRole { get; private set; }

        public LoginValidation(string username, string password, ActionOnError actionOnError)
        {
            Username = username;
            Password = password;
            _actionOnError = actionOnError;
        }
        public bool ValidateUserInput(User user)
        {
            Boolean emptyUserName;
            emptyUserName = user.Username.Equals(String.Empty);
            if (emptyUserName || user.Username.Length < 5)
            {
                //ErrorMessage = "Не е посочено валидно потребителско име.";
                _actionOnError("Не е посочено валидно потребителско име.");
                SetUserRoleToAnonymous();
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = user.Password.Equals(String.Empty);
            if (emptyPassword || user.Password.Length < 5)
            {
                //ErrorMessage = "Не е посочена валидна парола.";
                _actionOnError("Не е посочена валидна парола.");
                SetUserRoleToAnonymous();
                return false;
            }

            LoggedUser = UserData.IsUserPassCorrect(user.Username, user.Password);
            if (LoggedUser == null)
            {
                //ErrorMessage = "Не е намерен потребител с посочените потребителско име и парола.";
                _actionOnError("Не е намерен потребител с посочените потребителско име и парола.");
                SetUserRoleToAnonymous();
                return false;
            }

            CurrentUserRole = (UserRoles)LoggedUser.Role;
            Logger.Hristiyan.PS.Logger.LogActivity("Успешен Login");

            return true;
        }

        private void SetUserRoleToAnonymous()
        {
            CurrentUserRole = UserRoles.ANONYMOUS;
        }
    }
}
