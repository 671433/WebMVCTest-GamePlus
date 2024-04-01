using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMVCTest.Migrations
{
    /// <inheritdoc />
    public partial class editIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cover",
                table: "Games",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "ID",
                keyValue: 2,
                column: "Icon",
                value: "bi bi-xbox");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "ID",
                keyValue: 3,
                column: "Icon",
                value: "bi bi-nintendo-switch");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "ID",
                keyValue: 4,
                column: "Icon",
                value: "bi bi-pc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cover",
                table: "Games",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "ID",
                keyValue: 2,
                column: "Icon",
                value: "bi bi-playstation");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "ID",
                keyValue: 3,
                column: "Icon",
                value: "bi bi-playstation");

            migrationBuilder.UpdateData(
                table: "Devices",
                keyColumn: "ID",
                keyValue: 4,
                column: "Icon",
                value: "bi bi-playstation");
        }
    }
}
