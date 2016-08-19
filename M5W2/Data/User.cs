using M5W2.M5W2.Util;

namespace M5W2.M5W2.Data
{
    public class User
    {
        private static string userName;
        private static string password;

        private User()
        {
        }

        public static string UserName()
        {
            return userName ?? (userName = PropertiesGetter.Email);
        }

        public static string Password()
        {
            return password ?? (password = PropertiesGetter.Password);
        }
    }
}
