using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPES.Services.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class EmailTesting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f1258201-e6e1-4db9-b269-7b733853d04f", "AQAAAAIAAYagAAAAEFGFgFXtj91M8tpZ7EFVq2Mg5XNKGxqrc/jAMMATjjYcjwQx+h4Qx+ER1WM0cDRirQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee70f471-c4f1-47dc-a3ff-db4c777e3b5d", "AQAAAAIAAYagAAAAEKFB5mf8916JktgEQIQOr0dTtgZ4aDUcuzdWiUn6c+Gr+ZzIuzNDwK+jd0mZsFzC2g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a55b5e6-177d-490d-bddf-f4f8712d6ee6", "AQAAAAIAAYagAAAAEAq3vfUPgnyw5PDmSFBbUJSJNFqXMJKRN9tPnZe/DRxI6/s9Df/nxTsHtgr5ZympNQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ee6add8b-ec37-407b-8217-82c1acb739b2", "AQAAAAIAAYagAAAAEJ4mMar567za8SRoKW8POCs5/jvo2OJPNayJIj7LEAYL8QsUBzPWdm3Yudf2uowcMg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "38504c4c-a96a-4801-b17a-529933184ba9", "AQAAAAIAAYagAAAAEAR12kv++OQMAx6QaxYtBErY+H4e1QW5NGu3UpgX7u+OIV3xljMVFn33V4kL7DKYSg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b21ba37b-cfe0-491a-912e-0cb5fb2a792f", "AQAAAAIAAYagAAAAEI9kPAHukNc7EOj90rAiHV1pnqVBR7Q/jJ9UGFLekMFw/RYMS/Uvt3hig9IjSfdTwA==" });
        }
    }
}
