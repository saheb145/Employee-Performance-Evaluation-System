﻿// <auto-generated />
using System;
using EPES.Services.PerformanceEvaluationAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EPES.Services.PerformanceEvaluationAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230923084207_modifyselfevalutionModel")]
    partial class modifyselfevalutionModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID")
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

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.Dto.ApplicationUserDto", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID")
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

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("ApplicationUserDto");
                });

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.ManagerEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ManagerEvaluations");
                });

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.SelfEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Adaptability")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserDtoEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Commmunication")
                        .HasColumnType("int");

                    b.Property<int>("GoalAchievement")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskCompleted")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Technical")
                        .HasColumnType("int");

                    b.Property<int>("TimeManagement")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserDtoEmail");

                    b.ToTable("SelfEvaluations");
                });

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.SelfEvaluation", b =>
                {
                    b.HasOne("EPES.Services.PerformanceEvaluationAPI.Models.Dto.ApplicationUserDto", "ApplicationUserDto")
                        .WithMany()
                        .HasForeignKey("ApplicationUserDtoEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUserDto");
                });
#pragma warning restore 612, 618
        }
    }
}