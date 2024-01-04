using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderManagerApp.Migrations
{
    public partial class AddFileSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomFileSize",
                table: "Files",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomFileSize",
                table: "Files");
        }
    }
}
