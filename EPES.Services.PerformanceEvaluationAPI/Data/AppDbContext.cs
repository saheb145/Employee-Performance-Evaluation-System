using EPES.Services.PerformanceEvaluationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EPES.Services.PerformanceEvaluationAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for your data models, including SelfEvaluation.
        public DbSet<SelfEvaluation> SelfEvaluations { get; set; }

        // Add DbSet properties for other models if needed.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure your database relationships and constraints here.
            // For example, configure foreign keys and indices.
        }
    }
}
