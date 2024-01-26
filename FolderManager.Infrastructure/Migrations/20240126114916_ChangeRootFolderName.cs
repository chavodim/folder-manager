using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderManagerApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRootFolderName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 1,
                columns: new[] { "FolderName", "FolderPath" },
                values: new object[] { "root", "root" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 2,
                column: "FolderPath",
                value: "root\\files");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 1,
                columns: new[] { "FolderName", "FolderPath" },
                values: new object[] { "wwwroot", "wwwroot" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 2,
                column: "FolderPath",
                value: "wwwroot\\files");
        }
    }
}
