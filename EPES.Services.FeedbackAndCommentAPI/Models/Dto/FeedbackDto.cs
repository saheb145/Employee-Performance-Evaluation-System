namespace EPES.Services.FeedbackAndCommentAPI.Models.Dto
{
	public class FeedbackDto
	{
		public string EmployeeEmail { get; set; }
		public string Content { get; set; }
		public DateTime CreatedDate { get; set; }
	}
}
