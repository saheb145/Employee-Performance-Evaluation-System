using System.Collections.Generic;
using EPES.Services.PerformanceEvaluationAPI.Models;
using Microsoft.EntityFrameworkCore;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;

namespace EPES.Services.PerformanceEvaluationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<SelfEvaluation> SelfEvaluations { get; set; }
        public DbSet<ManagerEvaluation> ManagerEvaluations { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var server = "(localdb)";
        //    var instance = "mssqllocaldb";
        //    var database = "SelfEvaluatioDB";
        //    var authentication = "Integrated Security = true";

        //    var conString = $"Data Source={server}\\{instance}; Initial Catalog={database};{authentication}";

        //    options.UseSqlServer(conString);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Employee>()
        //.HasOne(e => e.SelfEvaluation)
        //.WithOne(se => se.Employee)
        //.HasForeignKey<SelfEvaluation>(se => se.EmployeeId);

        }

        }
    }
