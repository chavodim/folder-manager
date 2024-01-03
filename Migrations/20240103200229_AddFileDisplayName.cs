using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderManagerApp.Migrations
{
    public partial class AddFileDisplayName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders");

            migrationBuilder.AddColumn<string>(
                name: "CustomDisplayName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 1,
                column: "CustomDisplayName",
                value: "File 1");

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 2,
                column: "CustomDisplayName",
                value: "File 2");

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 3,
                column: "CustomDisplayName",
                value: "File 3");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 2,
                column: "FolderPath",
                value: "wwwroot\\files");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "FolderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders");

            migrationBuilder.DropColumn(
                name: "CustomDisplayName",
                table: "Files");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "FolderId",
                keyValue: 2,
                column: "FolderPath",
                value: "wwwroot/files");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId",
                principalTable: "Folders",
                principalColumn: "FolderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
