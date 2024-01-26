using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FolderManagerApp.Migrations
{
    public partial class AddMoreFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "CustomFileId", "CustomFileData", "CustomFileFormat", "CustomFileName", "ParentFolderId" },
                values: new object[] { 2, new byte[] { 66, 121, 101, 32, 87, 111, 114, 108, 100, 33 }, "txt", "File 2", 1 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "CustomFileId", "CustomFileData", "CustomFileFormat", "CustomFileName", "ParentFolderId" },
                values: new object[] { 3, new byte[] { 72, 101, 108, 108, 111, 32, 97, 103, 97, 105, 110, 33 }, "txt", "File 3", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "CustomFileId",
                keyValue: 3);
        }
    }
}
