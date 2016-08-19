using M5W2.Properties;

namespace M5W2.M5W2.Util
{
    class PropertiesGetter
    {
        public static string Email => Settings.Default["email"].ToString();
        public static string Url => Settings.Default["url"].ToString();
        public static string Password => Settings.Default["password"].ToString();
        public static string Browser => Settings.Default["browser"].ToString();
       
    }
}