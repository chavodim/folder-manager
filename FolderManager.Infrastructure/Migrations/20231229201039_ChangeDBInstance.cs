using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderManagerApp.Migrations
{
    public partial class ChangeDBInstance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 1,
                column: "FolderName",
                value: "wwwroot");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 2,
                column: "FolderName",
                value: "files");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 1,
                column: "FolderName",
                value: "/wwwroot");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 2,
                column: "FolderName",
                value: "/files");
        }
    }
}
