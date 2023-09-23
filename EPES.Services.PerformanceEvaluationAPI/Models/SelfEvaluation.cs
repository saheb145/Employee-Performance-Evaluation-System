﻿using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPES.Services.PerformanceEvaluationAPI.Models
{
    public class SelfEvaluation
    {
        public int Id { get; set; }
        //  public int EmployeeId { get; set; } // The ID of the employee who is submitting the evaluation.
        [ForeignKey("ApplicationUserDtoEmail")]
        public string ApplicationUserDtoEmail {  get; set; }
      
        public DateTime? SubmissionDate { get; set; }
        public String? TaskCompleted { get; set; }

        public int Technical { get; set; }
        public int Commmunication { get; set; }
        public int Adaptability { get; set; }
        public int TimeManagement { get; set; }
        public int GoalAchievement { get; set; }

        public ApplicationUserDto? ApplicationUserDto { get; set; }

    }
}
