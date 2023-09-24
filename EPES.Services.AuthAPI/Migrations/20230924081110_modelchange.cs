using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class modelchange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e6185bc-6f79-483f-bc79-fb66f9568243", "AQAAAAIAAYagAAAAEGLhhDdSrzTQp5RaeMhBZx3PGZw15rfvnar+yueErWnVSCVisHJs2/kLC08n+NMfWw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2db8b975-401c-4d0a-a2f9-c14a94d59b92", "AQAAAAIAAYagAAAAEGdYyKhD31bpS18sN8qaSDSoGDW1gPGzZWYX3jvkPo0BVCOIwTKhvywWHI+kDDhRMQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6cdad459-cd84-430e-8219-56875f29cc53", "AQAAAAIAAYagAAAAEMlfv8MdAPC4Oc8VSiLtwUhbSpVFZtdJ6nONF0H+3nrVW7pyC3i/dodponQmACdviA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50bb12aa-686a-4763-b029-e64096698557", "AQAAAAIAAYagAAAAEMvTtK4vDRA2nRRjf6VBoKIE1+GsEO5zDNRyxkF3ujevU12FwhVEp+aEXC2q0/nzmg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1c4541c8-8cd4-4bd7-900e-7e064a76adf9", "AQAAAAIAAYagAAAAEJikAweZ5WeCtKhmNOjFGkEMdmrNtAvKL/IyiBkvGG22aVSkyR3SZqh/RKH727W0IQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "13fc4fe8-1d47-4e23-af5b-cd6b58e0e28f", "AQAAAAIAAYagAAAAEDfCFkrhR2KMdMovC5mBd7onLQDz2z9gaYSqgvY9gitN96CxDIcDjrDIeauavsKueQ==" });
        }
    }
}
