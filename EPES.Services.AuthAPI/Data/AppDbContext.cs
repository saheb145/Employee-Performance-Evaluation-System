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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var hasher = new PasswordHasher<ApplicationUser>();
           
             var user=   new ApplicationUser
                {
                    Id = "1", // Replace with a unique ID for the user
                    UserName = "Manager",
                    NormalizedUserName = "MANAGER",
                    Name = "manager",
                    Email = "manager@gmail.com",
                    NormalizedEmail = "MANAGER@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Manager@123"), // Hash the password
                    SecurityStamp = string.Empty
                };
            
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            // Define the role
            var role = new IdentityRole
            {
                Id = "1", // Replace with a unique ID for the role
                Name = "MANAGER", // Replace with your desired role name
                NormalizedName = "MANAGER"
            };

            // Add the role to the database
            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Assign the role to the user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            });

        }
    }
}
