namespace EPES.Web.Utility
{
    public class SD
    {
        public static string AuthAPIBase { get; set; }
        public static string UserMangementAPIBase { get; set; }
        public const string RoleManager = "MANAGER";
        public const string RoleEmployee = "EMPLOYEE";
        public const string TokenCookie = "JWTToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
