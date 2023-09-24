namespace EPES.Services.PerformanceEvaluationAPI.Models.Dto
{
    public class ManagerEvaluationDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; } 
        public string Name { get; set; }
        public string Remarks { get; set; }

        public int Score { get; set; }
    }
}
