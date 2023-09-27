using System.Collections.Generic;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace EPES.Services.PerformanceEvaluationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<SelfEvaluation> SelfEvaluations { get; set; }
        public DbSet<ManagerEvaluation> ManagerEvaluations { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }

        }
    }
