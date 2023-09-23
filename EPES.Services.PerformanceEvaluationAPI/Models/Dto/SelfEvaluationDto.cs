namespace EPES.Services.PerformanceEvaluationAPI.Models.Dto
{
    public class SelfEvaluationDto
    {
        public int Id { get; set; }
      
        public string ApplicationUserDtoEmail { get; set; }
        public DateTime SubmissionDate { get; set; }
        public String TaskCompleted { get; set; }
        public int Technical { get; set; }
        public int Commmunication { get; set; }
        public int Adaptability { get; set; }
        public int TimeManagement { get; set; }
        public int GoalAchievement { get; set; }
        public ApplicationUserDto? ApplicationUserDto { get; set; }
    }
}
