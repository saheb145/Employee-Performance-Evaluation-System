namespace EPES.Services.UserMangement.Model.Dto
{
    public class LoginResponseDto
    {
        public EmployeeDto Employee { get; set; }
        public string Token { get; set; }
    }
}
