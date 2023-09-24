using System.Collections.Generic;
using EPES.Services.PerformanceEvaluationAPI.Models;
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

        public DbSet<User> Users { get; set; }
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
        }

        }
    }
