using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EPES.Services.UserMangement.Migrations
{
    /// <inheritdoc />
    public partial class seedDataTotableEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "saheb@gmail.com", "saheb", "Saheb@123", "778-0828780", "Employee" },
                    { 2, "ankit@gmail.com", "ankit", "Ankit@123", "7903373058", "Employee" },
                    { 3, "bhargav@gmail.com", "bhargav", "bhargav@123", "7903373058", "Employee" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
