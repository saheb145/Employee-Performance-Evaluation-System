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

       /* public DbSet<UserDto> Users { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          /*  modelBuilder.Entity<SelfEvaluation>()
          .HasKey(se => se.Id); // Define the primary key for SelfEvaluation if not done already

            modelBuilder.Entity<SelfEvaluation>()
                .HasOne<UserDto>() // Specify the related entity type (UserDto)
                .WithMany()        // Assuming no navigation property from UserDto to SelfEvaluation
                .HasForeignKey(se => se.Email);*/


            base.OnModelCreating(modelBuilder);
        }

        }
    }
