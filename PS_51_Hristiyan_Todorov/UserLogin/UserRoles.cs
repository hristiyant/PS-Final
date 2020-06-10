namespace UserLogin 
{
    public enum UserRoles 
    {
        NONE,
        ANONYMOUS,
        ADMIN,
        INSPECTOR,
        PROFESSOR,
        STUDENT
    }

    public static class UserRolesExtensions
    {
        public static string ToFriendlyString(this UserRoles me)
        {
            switch (me)
            {
                case UserRoles.ANONYMOUS:
                    return "ANONYMOUS";
                case UserRoles.ADMIN:
                    return "ADMIN";
                case UserRoles.INSPECTOR:
                    return "INSPECTOR";
                case UserRoles.PROFESSOR:
                    return "PROFESSOR";
                case UserRoles.STUDENT:
                    return "STUDENT";
                default:
                    return "Empty";
            }
        }
    }
}