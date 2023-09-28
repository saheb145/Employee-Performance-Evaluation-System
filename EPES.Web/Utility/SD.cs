namespace EPES.Web.Utility
{
    public class SD
    {
        public static string AuthAPIBase { get; set; }
        public static string SelfEvaluationAPIBase { get; set; }
        public static string UserAPIBase { get; set; }
        public static string ProfileAPIBase { get; set; }
		/*public static string FeedbackAPIBase { get; set; }*/
		public static string ManagerEvaluationAPIBase { get; set; }

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
