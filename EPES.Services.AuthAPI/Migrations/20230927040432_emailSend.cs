using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class emailSend : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d07387df-1215-442a-bb08-a8fbfd69a16a", "AQAAAAIAAYagAAAAEMBMFAwT1cEcAmEnJ9Edb39AVJhthhk2NgPUNEVrXdLouAFVbvEwFYkfDYlLAY0+nA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "85207aea-d4ff-465f-a22b-7a45b45889c4", "AQAAAAIAAYagAAAAEHKF9Li7543Ew0H2uwnPVNWh+jNMXUsz2pWgCAiQevqu1Bh+sN3oKI7ZNKycXbsQOw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f59b9b3a-c0f2-4f18-b5eb-2bde90d92a40", "AQAAAAIAAYagAAAAEJiA9wR1h0AR9n0E+1zOCYNgCdj2iJlyuMIYO/lGITgCemqCH4KdW2blSlY2gWrPTQ==" });
        }
    }
}
