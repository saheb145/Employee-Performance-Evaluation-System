namespace EPES.Services.NotificationsAndAlertsAPI.Models.Dto
{
	public class ApiResponseDto
	{
		public List<UserDto> Result { get; set; }
		public bool IsSuccess { get; set; }
		public string Message { get; set; }
	}
}
