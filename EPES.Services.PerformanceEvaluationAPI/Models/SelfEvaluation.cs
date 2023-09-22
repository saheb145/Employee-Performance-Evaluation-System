//using EPES.Services.UserMangement.Model;

using System.ComponentModel.DataAnnotations.Schema;

namespace EPES.Services.PerformanceEvaluationAPI.Models
{
    public class SelfEvaluation
    {
		public int Id { get; set; }
		public int EmployeeId { get; set; } // The ID of the employee who is submitting the evaluation.
        //[ForeignKey("EmployeeId")] 
        public DateTime SubmissionDate { get; set; }
		public string TaskCompleted { get; set; }
		public string GoodAttendance { get; set; }

        // Navigation property for Employee
        //public Employee Employee { get; set; }

    }
}
