using EPES.Services.FeedbackAndCommentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EPES.Services.FeedbackAndCommentAPI.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Feedback> Feedbacks { get; set; }
		


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);
		}

	}
}

