using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace EPES.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			var hasher = new PasswordHasher<ApplicationUser>();

			var managerUser = new ApplicationUser
			{
				Id = "1", // Replace with a unique ID for the Manager user
				UserName = "manager@gmail.com",
				NormalizedUserName = "MANAGER@GMAIL.COM",
				Name = "manager",
				Email = "manager@gmail.com",
				NormalizedEmail = "MANAGER@GMAIL.COM",
				PhoneNumber = "7903373058",
				PhoneNumberConfirmed = true,
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "Manager@123"), // Hash the password
				SecurityStamp = string.Empty
			};

			
			modelBuilder.Entity<ApplicationUser>().HasData(managerUser);

			// Define the roles
			var managerRole = new IdentityRole
			{
				Id = "1", 
				Name = "MANAGER",
				NormalizedName = "MANAGER"
			};

			
			// Add the roles to the database
			modelBuilder.Entity<IdentityRole>().HasData(managerRole);

			// Assign roles to users
			modelBuilder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					UserId = managerUser.Id,
					RoleId = managerRole.Id
				}
				
			);
		}
	}
}
