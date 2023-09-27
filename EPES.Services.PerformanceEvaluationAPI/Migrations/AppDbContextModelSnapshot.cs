﻿// <auto-generated />
using System;
using EPES.Services.PerformanceEvaluationAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EPES.Services.PerformanceEvaluationAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.ManagerEvaluation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeEmail")
                        .IsUnique();

                    b.ToTable("ManagerEvaluations");
                });

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.SelfEvaluation", b =>
                {
                    b.Property<string>("EmployeeEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Adaptability")
                        .HasColumnType("int");

                    b.Property<int>("Communication")
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

                    b.HasKey("EmployeeEmail");

                    b.ToTable("SelfEvaluations");
                });

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.ManagerEvaluation", b =>
                {
                    b.HasOne("EPES.Services.PerformanceEvaluationAPI.Models.SelfEvaluation", "SelfEvaluation")
                        .WithOne("ManagerEvaluation")
                        .HasForeignKey("EPES.Services.PerformanceEvaluationAPI.Models.ManagerEvaluation", "EmployeeEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SelfEvaluation");
                });

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.SelfEvaluation", b =>
                {
                    b.Navigation("ManagerEvaluation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}