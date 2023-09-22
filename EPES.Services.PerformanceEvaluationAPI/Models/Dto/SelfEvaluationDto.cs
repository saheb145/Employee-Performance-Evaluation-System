using System.ComponentModel.DataAnnotations.Schema;

namespace EPES.Services.PerformanceEvaluationAPI.Models.Dto
{
    public class SelfEvaluationDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } // The ID of the employee who is submitting the evaluation.

        public DateTime SubmissionDate { get; set; }
        public string TaskCompleted { get; set; }
        public string GoodAttendance { get; set; }

        // Navigation property for Employee
       // public Employee Employee { get; set; }
        // Navigation property for Employee

    }
}
