using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EPES.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class employeeSeeddataremove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "UserName" },
                values: new object[] { "5da12cb7-6463-4cd5-92da-5a7f463fbae5", "MANAGER@GMAIL.COM", "AQAAAAIAAYagAAAAEBed+x1LfFD+902IN01KXZoTf+qVcvitI8Uk1lFY7GcswrpM5rXEcvhJUxM8UU0Nog==", "7903373058", true, "manager@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2", null, "EMPLOYEE", "EMPLOYEE" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "UserName" },
                values: new object[] { "d36f0676-38f5-4627-88cd-12c664429f79", "MANAGER", "AQAAAAIAAYagAAAAEP6YLgpmd2/QVRqOEZL7mcQ/9f9H11jyLE2XIZ3ZbERyyx89m7cJhkUB5XOlR7E1pQ==", null, false, "Manager" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2", 0, "1fe74b0b-7545-44d0-80b7-45eb0f6961ce", "Saheb@gmail.com", true, false, null, "saheb kumar", "SAHEB@GMAIL.COM", "SAHEBKUMAR", "AQAAAAIAAYagAAAAELDe01BJZfRF+/6W04AbHrrqvPdRVMDJNx9XcVyhHmBj7HDAfyzF8BuICxu8BIc5Lg==", null, false, "", false, "SahebKumar" },
                    { "3", 0, "46613140-2a89-4e5d-9ba0-c44c2f45d504", "ankit@gmail.com", true, false, null, "Ankit Kumar", "ANKIT@GMAIL.COM", "ANKITKUMAR", "AQAAAAIAAYagAAAAEBipCzYg/FAWZ6pnxmqYV4gVFfzlH1ezVzwAbiX/wpshiQP1z8uv9Acvb7mWYT4AAg==", null, false, "", false, "AnkitKumar" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "2" },
                    { "2", "3" }
                });
        }
    }
}
