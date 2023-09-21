﻿namespace EPES.Web.Models
{
    public class SelfEvaluationDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; } // The ID of the employee who is submitting the evaluation.
        public DateTime SubmissionDate { get; set; }
        public String TaskCompleted { get; set; }

        public string GoodAttendance { get; set; }
    }
}
