﻿// <auto-generated />
using System;
using FolderManagerApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FolderManagerApp.Migrations
{
    [DbContext(typeof(FolderManagerDbContext))]
    [Migration("20240126114916_ChangeRootFolderName")]
    partial class ChangeRootFolderName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FolderManagerApp.Models.CustomFile", b =>
                {
                    b.Property<int>("CustomFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomFileId"));

                    b.Property<string>("CustomDisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("CustomFileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CustomFileFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CustomFileSize")
                        .HasColumnType("float");

                    b.Property<int>("ParentFolderId")
                        .HasColumnType("int");

                    b.HasKey("CustomFileId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            CustomFileId = 1,
                            CustomDisplayName = "File 1",
                            CustomFileData = new byte[] { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33 },
                            CustomFileFormat = "txt",
                            CustomFileName = "File 1",
                            CustomFileSize = 1000.0,
                            ParentFolderId = 2
                        },
                        new
                        {
                            CustomFileId = 2,
                            CustomDisplayName = "File 2",
                            CustomFileData = new byte[] { 66, 121, 101, 32, 87, 111, 114, 108, 100, 33 },
                            CustomFileFormat = "txt",
                            CustomFileName = "File 2",
                            CustomFileSize = 1000.0,
                            ParentFolderId = 2
                        },
                        new
                        {
                            CustomFileId = 3,
                            CustomDisplayName = "File 3",
                            CustomFileData = new byte[] { 72, 101, 108, 108, 111, 32, 97, 103, 97, 105, 110, 33 },
                            CustomFileFormat = "txt",
                            CustomFileName = "File 3",
                            CustomFileSize = 1000.0,
                            ParentFolderId = 2
                        });
                });

            modelBuilder.Entity("FolderManagerApp.Models.Folder", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FolderId"));

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FolderPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentFolderId")
                        .HasColumnType("int");

                    b.HasKey("FolderId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            FolderId = 1,
                            FolderName = "root",
                            FolderPath = "root"
                        },
                        new
                        {
                            FolderId = 2,
                            FolderName = "files",
                            FolderPath = "root\\files",
                            ParentFolderId = 1
                        });
                });

            modelBuilder.Entity("FolderManagerApp.Models.CustomFile", b =>
                {
                    b.HasOne("FolderManagerApp.Models.Folder", "ParentFolder")
                        .WithMany("Files")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("FolderManagerApp.Models.Folder", b =>
                {
                    b.HasOne("FolderManagerApp.Models.Folder", "ParentFolder")
                        .WithMany("ChildrenFolders")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("FolderManagerApp.Models.Folder", b =>
                {
                    b.Navigation("ChildrenFolders");

                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
