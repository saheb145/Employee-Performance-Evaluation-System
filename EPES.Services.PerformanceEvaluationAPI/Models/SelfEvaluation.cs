using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPES.Services.PerformanceEvaluationAPI.Models
{
    public class SelfEvaluation
    {
      
          

            public DateTime? SubmissionDate { get; set; }
            public String? TaskCompleted { get; set; }
             [Key]
            public string EmployeeEmail { get; set; }

            public int Technical { get; set; }
            public int Communication { get; set; }
            public int Adaptability { get; set; }
            public int TimeManagement { get; set; }
            public int GoalAchievement { get; set; }

		public virtual ManagerEvaluation ManagerEvaluation { get; set; }

	}
}
