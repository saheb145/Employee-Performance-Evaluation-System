namespace EPES.Services.PerformanceEvaluationAPI.Models.Dto
{
    public class ManagerEvaluationDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; } // The ID of the employee who is submitting the evaluation.
        public string Name { get; set; }
        public string Remarks { get; set; }

        public int Score { get; set; }
    }
}
