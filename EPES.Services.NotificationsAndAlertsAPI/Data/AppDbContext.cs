using EPES.Services.NotificationsAndAlertsAPI.Models.Dto;
using EPES.Services.PerformanceEvaluationAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Collections.Generic;

namespace EPES.Services.NotificationsAndAlertsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       /* public DbSet<SelfEvaluation> SelfEvaluations { get; set; }*/
        public DbSet<User> Users { get; set; }

       

        // DbSet properties...

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure your database provider and connection string here
                optionsBuilder.UseSqlServer("YourConnectionString"); // Replace with your connection string
            }
        }
    }

}
