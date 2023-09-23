namespace EPES.Web.Utility
{
    public class SD
    {
        public static string AuthAPIBase { get; set; }
        public static string SelfEvaluationAPIBase { get; set; }
        public static string UserMangementAPIBase { get; set; }
        public static string UserAPIBase { get; set; }
        public const string RoleManager = "MANAGER";
        public static string ManagerEvaluationAPIBase { get; set; }
        
		
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
