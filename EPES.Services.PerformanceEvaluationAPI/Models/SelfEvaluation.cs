using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPES.Services.PerformanceEvaluationAPI.Models
{
    public class SelfEvaluation
    {
        /*  public int Id { get; set; }

          [ForeignKey("UserDtoEmail")]
          public string UserDtoEmail {  get; set; }

          public DateTime? SubmissionDate { get; set; }
          public String? TaskCompleted { get; set; }

          public int Technical { get; set; }
          public int Commmunication { get; set; }
          public int Adaptability { get; set; }
          public int TimeManagement { get; set; }
          public int GoalAchievement { get; set; }
  */
        //  public UserDto UserDto { get; set; }

       
            public int Id { get; set; }

            public DateTime? SubmissionDate { get; set; }
            public String? TaskCompleted { get; set; }

            // Foreign key to represent the User's Email
            [ForeignKey("Email")]
            public string Email { get; set; }

            public int Technical { get; set; }
            public int Communication { get; set; }
            public int Adaptability { get; set; }
            public int TimeManagement { get; set; }
            public int GoalAchievement { get; set; }

            

    }
}
