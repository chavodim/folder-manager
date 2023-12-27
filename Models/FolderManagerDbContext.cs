
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Models
{
    public class FolderManagerDbContext : DbContext
    {
        public FolderManagerDbContext(DbContextOptions<FolderManagerDbContext> options) :
        base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<Folder> Folders { get; set; }

        public DbSet<CustomFile> Files { get; set; }
        
    }
}