using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.PerformanceEvaluationAPI.Migrations
{
    /// <inheritdoc />
    public partial class modifyselfevalutionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoodAttendance",
                table: "SelfEvaluations");

            migrationBuilder.AlterColumn<string>(
                name: "TaskCompleted",
                table: "SelfEvaluations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionDate",
                table: "SelfEvaluations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Adaptability",
                table: "SelfEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Commmunication",
                table: "SelfEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GoalAchievement",
                table: "SelfEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Technical",
                table: "SelfEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TimeManagement",
                table: "SelfEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adaptability",
                table: "SelfEvaluations");

            migrationBuilder.DropColumn(
                name: "Commmunication",
                table: "SelfEvaluations");

            migrationBuilder.DropColumn(
                name: "GoalAchievement",
                table: "SelfEvaluations");

            migrationBuilder.DropColumn(
                name: "Technical",
                table: "SelfEvaluations");

            migrationBuilder.DropColumn(
                name: "TimeManagement",
                table: "SelfEvaluations");

            migrationBuilder.AlterColumn<string>(
                name: "TaskCompleted",
                table: "SelfEvaluations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionDate",
                table: "SelfEvaluations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoodAttendance",
                table: "SelfEvaluations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
