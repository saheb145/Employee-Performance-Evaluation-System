﻿// <auto-generated />
using System;
using EPES.Services.NotificationsAndAlertsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EPES.Services.NotificationsAndAlertsAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230925152257_EmailTesting")]
    partial class EmailTesting
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<int>("Id")
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

            modelBuilder.Entity("EPES.Services.PerformanceEvaluationAPI.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
