namespace EPES.Services.PerformanceEvaluationAPI.Models.Dto
{
    public class ManagerEvaluationDto
    {
        public int Id { get; set; }

        public int UniqueEID { get; set; } // The ID of the employee who is submitting the evaluation.
        public string Name { get; set; }

        public string Email { get; set; }
        public string Feedback { get; set; }

        public int ManagerScore { get; set; }
    }
}
