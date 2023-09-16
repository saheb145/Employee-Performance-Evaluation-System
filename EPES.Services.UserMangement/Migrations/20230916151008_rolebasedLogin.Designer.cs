﻿// <auto-generated />
using EPES.Services.UserMangement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EPES.Services.UserMangement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230916151008_rolebasedLogin")]
    partial class rolebasedLogin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EPES.Services.UserMangement.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "saheb@gmail.com",
                            Name = "saheb",
                            Password = "Saheb@123",
                            PhoneNumber = "778-0828780",
                            Role = "Employee"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ankit@gmail.com",
                            Name = "ankit",
                            Password = "Ankit@123",
                            PhoneNumber = "7903373058",
                            Role = "Employee"
                        },
                        new
                        {
                            Id = 3,
                            Email = "bhargav@gmail.com",
                            Name = "bhargav",
                            Password = "bhargav@123",
                            PhoneNumber = "7903373058",
                            Role = "Employee"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
