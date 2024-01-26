using FolderManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Data
{
    public class FolderManagerDbContext : DbContext
    {
        public FolderManagerDbContext(DbContextOptions<FolderManagerDbContext> options) : base(options)
        {
        }

        public DbSet<Folder> Folders { get; set; }

        public DbSet<CustomFile> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Folder>()
           .HasMany(f => f.ChildrenFolders)
           .WithOne(p => p.ParentFolder)
           .HasForeignKey(p => p.ParentFolderId)
           .OnDelete(DeleteBehavior.NoAction);

        }
    }
}