using System.ComponentModel.DataAnnotations.Schema;

namespace EPES.Services.PerformanceEvaluationAPI.Models.Dto
{
    public class SelfEvaluationDto
    {
        public DateTime? SubmissionDate { get; set; }
        public String? TaskCompleted { get; set; }
        public string EmployeeEmail { get; set; }
        public int Technical { get; set; }
        public int Communication { get; set; }
        public int Adaptability { get; set; }
        public int TimeManagement { get; set; }
        public int GoalAchievement { get; set; }
    }
}
