﻿using System.ComponentModel.DataAnnotations;

namespace EPES.Services.PerformanceEvaluationAPI.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }

        public SelfEvaluation SelfEvaluation { get; set; }
    }
}
