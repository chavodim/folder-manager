using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderManagerApp.Migrations
{
    public partial class AddSecondFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 1,
                column: "FolderName",
                value: "/wwwroot");

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "FolderId", "FolderName", "ParentFolderId" },
                values: new object[] { 2, "/files", 1 });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 1,
                column: "ParentFolderId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 2,
                column: "ParentFolderId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 3,
                column: "ParentFolderId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 1,
                column: "ParentFolderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 2,
                column: "ParentFolderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 3,
                column: "ParentFolderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 1,
                column: "FolderName",
                value: "/files/");
        }
    }
}
