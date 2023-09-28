using System.ComponentModel.DataAnnotations;

namespace EPES.Services.FeedbackAndCommentAPI.Models
{
	public class Feedback
	{
		[Key]
		public int Id { get; set; }		
		public string EmployeeEmail {  get; set; }
		public string Content { get; set; }	
		public DateTime CreatedDate { get; set; }
	}
}
