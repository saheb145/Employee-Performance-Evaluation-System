namespace EPES.Web.Models
{
    public class SelfEvaluationDto
    {
        public int Id { get; set; }
        public string UniqueEID { get; set; } // The ID of the employee who is submitting the evaluation.
        public string Name { get; set; }
        public string Email { get; set; }//[ForeignKey("EmployeeId")] 
        public int Technical { get; set; }
        public int Communication { get; set; }
        public int Adaptability { get; set; }
        public int TimeManagement { get; set; }
        public int GoalAchievement { get; set; }
    }
}
