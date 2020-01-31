using System.Configuration;

namespace FE_WebApp
{
    public class Constants
    {
        public static string ApiBaseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
        public static string GetWordRepresentationOfNumberApiUrl = ConfigurationManager.AppSettings["GetWordRepresentationOfNumberApiUrl"];
    }
}