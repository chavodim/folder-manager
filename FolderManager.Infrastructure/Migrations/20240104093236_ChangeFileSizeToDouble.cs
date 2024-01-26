using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderManagerApp.Migrations
{
    public partial class ChangeFileSizeToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "CustomFileSize",
                table: "Files",
                type: "float",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 1,
                column: "CustomFileSize",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 2,
                column: "CustomFileSize",
                value: 1000.0);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 3,
                column: "CustomFileSize",
                value: 1000.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CustomFileSize",
                table: "Files",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 1,
                column: "CustomFileSize",
                value: 1000L);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 2,
                column: "CustomFileSize",
                value: 1000L);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 3,
                column: "CustomFileSize",
                value: 1000L);
        }
    }
}
