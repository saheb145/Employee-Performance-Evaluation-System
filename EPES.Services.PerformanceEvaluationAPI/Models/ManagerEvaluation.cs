using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPES.Services.PerformanceEvaluationAPI.Models
{
    public class ManagerEvaluation
    {
        [Key]
        public int Id { get; set; }
        public string EmployeeEmail {  get; set; }
        public string Remarks { get; set; }
        public int Score  { get; set; }

		[ForeignKey("EmployeeEmail")]
		public virtual SelfEvaluation SelfEvaluation { get; set; }

	}
}
