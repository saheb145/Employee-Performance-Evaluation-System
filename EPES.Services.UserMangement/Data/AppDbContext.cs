using EPES.Services.UserMangement.Model;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EPES.Services.UserMangement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Employee>()
          .HasIndex(e => e.UserName)
          .IsUnique();

            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
               Id = 1,
               Email="saheb@gmail.com",
               UserName="sahebKumar",
               Name="saheb",
               Password="Saheb@123",
               PhoneNumber="778-0828780",
               Role="Employee"
            });


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 2,
                Email = "ankit@gmail.com",
                Name = "ankit",
                UserName="ankitkumar",
                Password = "Ankit@123",
                PhoneNumber = "7903373058",
                Role = "Employee"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 3,
                Email = "bhargav@gmail.com",
                Name = "bhargav",
                UserName="bhargavKumar",
                Password = "bhargav@123",
                PhoneNumber = "7903373058",
                Role = "Employee"
            });
        }
    }
}