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
    [Migration("20231228201850_AddMoreFiles")]
    partial class AddMoreFiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FolderManagerApp.Models.CategoryDao", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Category 1"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Category 2"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Category 3"
                        });
                });

            modelBuilder.Entity("FolderManagerApp.Models.CustomFileDao", b =>
                {
                    b.Property<int>("CustomFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomFileId"), 1L, 1);

                    b.Property<byte[]>("CustomFileData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CustomFileFormat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentFolderId")
                        .HasColumnType("int");

                    b.HasKey("CustomFileId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            CustomFileId = 1,
                            CustomFileData = new byte[] { 72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33 },
                            CustomFileFormat = "txt",
                            CustomFileName = "File 1",
                            ParentFolderId = 1
                        },
                        new
                        {
                            CustomFileId = 2,
                            CustomFileData = new byte[] { 66, 121, 101, 32, 87, 111, 114, 108, 100, 33 },
                            CustomFileFormat = "txt",
                            CustomFileName = "File 2",
                            ParentFolderId = 1
                        },
                        new
                        {
                            CustomFileId = 3,
                            CustomFileData = new byte[] { 72, 101, 108, 108, 111, 32, 97, 103, 97, 105, 110, 33 },
                            CustomFileFormat = "txt",
                            CustomFileName = "File 3",
                            ParentFolderId = 1
                        });
                });

            modelBuilder.Entity("FolderManagerApp.Models.FolderDao", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FolderId"), 1L, 1);

                    b.Property<string>("FolderName")
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
                            FolderName = "/files/"
                        });
                });

            modelBuilder.Entity("FolderManagerApp.Models.PieDao", b =>
                {
                    b.Property<int>("PieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PieId"), 1L, 1);

                    b.Property<string>("AllergyInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPieOfTheWeek")
                        .HasColumnType("bit");

                    b.Property<string>("LongDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PieId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Pies");

                    b.HasData(
                        new
                        {
                            PieId = 1,
                            CategoryId = 1,
                            ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypiesmall.jpg",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypie.jpg",
                            InStock = true,
                            IsPieOfTheWeek = false,
                            LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                            Name = "StÏrawberry Pie",
                            Price = 15.95m,
                            ShortDescription = "Lorem Ipsum"
                        },
                        new
                        {
                            PieId = 2,
                            CategoryId = 1,
                            ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/cheesecakesmall.jpg",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/cheesecake.jpg",
                            InStock = true,
                            IsPieOfTheWeek = false,
                            LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                            Name = "Cheese cake",
                            Price = 18.95m,
                            ShortDescription = "Lorem Ipsum"
                        },
                        new
                        {
                            PieId = 3,
                            CategoryId = 1,
                            ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/rhubarbpiesmall.jpg",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/rhubarbpie.jpg",
                            InStock = true,
                            IsPieOfTheWeek = true,
                            LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                            Name = "Rhubarb Pie",
                            Price = 15.95m,
                            ShortDescription = "Lorem Ipsum"
                        },
                        new
                        {
                            PieId = 4,
                            CategoryId = 1,
                            ImageThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/seasonal/pumpkinpiesmall.jpg",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/seasonal/pumpkinpie.jpg",
                            InStock = true,
                            IsPieOfTheWeek = true,
                            LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                            Name = "Pumpkin Pie",
                            Price = 12.95m,
                            ShortDescription = "Lorem Ipsum"
                        });
                });

            modelBuilder.Entity("FolderManagerApp.Models.CustomFileDao", b =>
                {
                    b.HasOne("FolderManagerApp.Models.FolderDao", "ParentFolder")
                        .WithMany("Files")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("FolderManagerApp.Models.FolderDao", b =>
                {
                    b.HasOne("FolderManagerApp.Models.FolderDao", "ParentFolder")
                        .WithMany("Children")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("FolderManagerApp.Models.PieDao", b =>
                {
                    b.HasOne("FolderManagerApp.Models.CategoryDao", "Category")
                        .WithMany("Pies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FolderManagerApp.Models.CategoryDao", b =>
                {
                    b.Navigation("Pies");
                });

            modelBuilder.Entity("FolderManagerApp.Models.FolderDao", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}