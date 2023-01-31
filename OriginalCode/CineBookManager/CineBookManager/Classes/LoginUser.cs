namespace CineBookManager.Classes
{
    public static class LoginUser
    {
        public static Models.User CurrentUser { get; set; }
        public static Models.UserSession CurrentUserSession { get; set; }
        //public static Models.User LoggedUser { get; set; }
        public static bool UserLogged { get { return CurrentUserSession != null; } }
        public static int? LoggedLanguagesId { get { return CurrentUser == null ? null : CurrentUser.LanguagesId; } }
    }
}
