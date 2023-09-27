using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class Modified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e06655a-e5f1-47ae-bae9-f16bc4151bac", "AQAAAAIAAYagAAAAELQ7+LiyhMqeNrIMpeRQOfKEjti4lM+tCdlFwbvTJhndYi1pbKSk9tj4r7MHLXPIRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e61e7a62-e86e-4343-a024-01c62fd80f89", "AQAAAAIAAYagAAAAED1oxAW7njc2Xnw+4H0ZqWrG2ruXzSd8Xen9hyqFEHAsPaDnSTztA+BKzKuWWf//ig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8c56e6f4-4047-4ba0-a1e9-946c7ff1dd84", "AQAAAAIAAYagAAAAEKQamVpczNsH6i8GhQdusIhAGfGqlRs+zD7sb1Gc2C72SDeC0hocNi7uJHDSjondNg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a20a4645-ca75-4822-8060-b8cc08b259f3", "AQAAAAIAAYagAAAAEAvYoEUrXxsmP0B4jhEKW1+6HZMMCKvXoEGPJeMoGeXB5UDi07BAoXGLKNdeHI2bvg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a324e193-14cc-4d6b-a826-6f181a5ea176", "AQAAAAIAAYagAAAAEP6oRItPLMScWs3pfkrUHINGccxMZXauPaouJRi6HSp42v5Kc185MXne14iraMpqCw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d496d28-6020-4dd5-a25e-30bb2fd95fe4", "AQAAAAIAAYagAAAAEBsnHtnGDhlo4taGt0e/um6i8TKE8yzBtT3g8A0pGmOB+8blE4eCddvspD0TA43vSA==" });
        }
    }
}
