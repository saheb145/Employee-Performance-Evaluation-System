using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class mobilenuberaddtomanager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed" },
                values: new object[] { "f4d63f69-14c0-4a0e-ac0f-b966656e8a79", "AQAAAAIAAYagAAAAEBf9Q/Fog5kYBXPa0/A54AXXUE7vIq4KIy6oMO2qjvSdurgFRA1JKRaZkACdqpmV2Q==", "7903373058", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed" },
                values: new object[] { "4e831ce0-29c4-499f-9903-09cd4b87ff3f", "AQAAAAIAAYagAAAAEEvX+qVnMuUWTdaOSVMkCUndQL6XpfmXOrCdgxfMPfrVu+BSjzOFkWPg/WWfHH6cXA==", null, false });
        }
    }
}
