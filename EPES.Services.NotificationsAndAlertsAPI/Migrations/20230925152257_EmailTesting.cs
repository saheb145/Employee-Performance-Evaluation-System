using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.NotificationsAndAlertsAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmailTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelfEvaluations",
                columns: table => new
                {
                    EmployeeEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaskCompleted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Technical = table.Column<int>(type: "int", nullable: false),
                    Communication = table.Column<int>(type: "int", nullable: false),
                    Adaptability = table.Column<int>(type: "int", nullable: false),
                    TimeManagement = table.Column<int>(type: "int", nullable: false),
                    GoalAchievement = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfEvaluations", x => x.EmployeeEmail);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelfEvaluations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
