using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.PerformanceEvaluationAPI.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SelfEvaluations");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserDtoEmail",
                table: "SelfEvaluations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserDtoID",
                table: "SelfEvaluations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserDto",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserDto", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelfEvaluations_ApplicationUserDtoID",
                table: "SelfEvaluations",
                column: "ApplicationUserDtoID");

            migrationBuilder.AddForeignKey(
                name: "FK_SelfEvaluations_ApplicationUserDto_ApplicationUserDtoID",
                table: "SelfEvaluations",
                column: "ApplicationUserDtoID",
                principalTable: "ApplicationUserDto",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SelfEvaluations_ApplicationUserDto_ApplicationUserDtoID",
                table: "SelfEvaluations");

            migrationBuilder.DropTable(
                name: "ApplicationUserDto");

            migrationBuilder.DropIndex(
                name: "IX_SelfEvaluations_ApplicationUserDtoID",
                table: "SelfEvaluations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserDtoEmail",
                table: "SelfEvaluations");

            migrationBuilder.DropColumn(
                name: "ApplicationUserDtoID",
                table: "SelfEvaluations");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "SelfEvaluations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
