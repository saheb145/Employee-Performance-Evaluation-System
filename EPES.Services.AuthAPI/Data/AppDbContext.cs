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
				UserName = "Manager",
				NormalizedUserName = "MANAGER",
				Name = "manager",
				Email = "manager@gmail.com",
				NormalizedEmail = "MANAGER@GMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "Manager@123"), // Hash the password
				SecurityStamp = string.Empty
			};

			var employee1User = new ApplicationUser
			{
				Id = "2", // Replace with a unique ID for the first Employee user
				UserName = "SahebKumar",
				NormalizedUserName = "SAHEBKUMAR",
				Name = "saheb kumar",
				Email = "Saheb@gmail.com",
				NormalizedEmail = "SAHEB@GMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "Saheb@123"), // Hash the password
				SecurityStamp = string.Empty
			};

			var employee2User = new ApplicationUser
			{
				Id = "3", // Replace with a unique ID for the second Employee user
				UserName = "AnkitKumar",
				NormalizedUserName = "ANKITKUMAR",
				Name = "Ankit Kumar",
				Email = "ankit@gmail.com",
				NormalizedEmail = "ANKIT@GMAIL.COM",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "Ankit@123"), // Hash the password
				SecurityStamp = string.Empty
			};

			modelBuilder.Entity<ApplicationUser>().HasData(managerUser, employee1User, employee2User);

			// Define the roles
			var managerRole = new IdentityRole
			{
				Id = "1", 
				Name = "MANAGER",
				NormalizedName = "MANAGER"
			};

			var employeeRole = new IdentityRole
			{
				Id = "2", 
				Name = "EMPLOYEE",
				NormalizedName = "EMPLOYEE"
			};

			// Add the roles to the database
			modelBuilder.Entity<IdentityRole>().HasData(managerRole, employeeRole);

			// Assign roles to users
			modelBuilder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					UserId = managerUser.Id,
					RoleId = managerRole.Id
				},
				new IdentityUserRole<string>
				{
					UserId = employee1User.Id,
					RoleId = employeeRole.Id
				},
				new IdentityUserRole<string>
				{
					UserId = employee2User.Id,
					RoleId = employeeRole.Id
				}
			);
		}
	}
}
