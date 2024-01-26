using FolderManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Data
{
    public class FolderManagerDbContext : DbContext
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FolderManagerDbContext(DbContextOptions<FolderManagerDbContext> options, IWebHostEnvironment webHostEnvironment) :
        base(options)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public DbSet<FolderDao> Folders { get; set; }

        public DbSet<CustomFileDao> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedFolders(modelBuilder);
            SeedCustomFiles(modelBuilder);
        }

        private void SeedFolders(ModelBuilder modelBuilder)
        {
            int index = _webHostEnvironment.WebRootPath.LastIndexOf(@"\");
            string rootFolderName = _webHostEnvironment.WebRootPath.Substring(index + 1);

            List<FolderDao> folders = new List<FolderDao>
            {
                new()
                {
                    FolderId = 1,
                    FolderName = rootFolderName,
                    FolderPath = rootFolderName
                },
                new()
                {
                    FolderId = 2,
                    FolderName = "files",
                    FolderPath = rootFolderName + @"\files",
                    ParentFolderId = 1
                }
            };

            modelBuilder.Entity<FolderDao>()
            .HasMany(f => f.ChildrenFolders)
            .WithOne(p => p.ParentFolder)
            .HasForeignKey(p => p.ParentFolderId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FolderDao>().HasData(folders);
        }

        private void SeedCustomFiles(ModelBuilder modelBuilder)
        {
            List<CustomFileDao> fileDaos = new List<CustomFileDao>
            {
                new()
                {
                    CustomFileId = 1,
                    CustomFileName = "File 1",
                    CustomDisplayName = "File 1",
                    CustomFileData = System.Text.Encoding.UTF8.GetBytes("Hello World!"),
                    ParentFolderId = 2,
                    CustomFileFormat = "txt",
                    CustomFileSize = 1000
                },
                new()
                {
                    CustomFileId = 2,
                    CustomFileName = "File 2",
                    CustomDisplayName = "File 2",
                    CustomFileData = System.Text.Encoding.UTF8.GetBytes("Bye World!"),
                    ParentFolderId = 2,
                    CustomFileFormat = "txt",
                    CustomFileSize = 1000
                },
                new()
                {
                    CustomFileId = 3,
                    CustomFileName = "File 3",
                    CustomDisplayName = "File 3",
                    CustomFileData = System.Text.Encoding.UTF8.GetBytes("Hello again!"),
                    ParentFolderId = 2,
                    CustomFileFormat = "txt",
                    CustomFileSize = 1000
                }
            };

            modelBuilder.Entity<CustomFileDao>().HasData(fileDaos);
        }
    }
}