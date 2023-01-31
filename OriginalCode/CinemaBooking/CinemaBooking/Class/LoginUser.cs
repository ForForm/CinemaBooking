namespace CinemaBooking
{
    public class LoginUser
    {
        public static User LoggedUser;
        public static bool UserLogged { get { return LoggedUser != null; } }
        public static int LoggedUserId { get { return LoggedUser == null ? 0 : LoggedUser.UserId; } }
        public static string LoggedUserCode { get { return LoggedUser == null ? null : LoggedUser.UserCode; } }
        public static string LoggedUserName { get { return LoggedUser == null ? null : LoggedUser.UserName; } }
        public static int? LoggedLanguagesId { get { return LoggedUser == null ? null : LoggedUser.LanguagesId; } }
        public static string SessionId;
    }
}
