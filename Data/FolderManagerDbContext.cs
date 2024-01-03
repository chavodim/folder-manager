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

        public DbSet<CategoryDao> Categories { get; set; }

        public DbSet<PieDao> Pies { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<OrderDao> Orders { get; set; }

        public DbSet<OrderDetailDao> OrderDetails { get; set; }

        public DbSet<FolderDao> Folders { get; set; }

        public DbSet<CustomFileDao> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            SeedFolders(modelBuilder);
            SeedCustomFiles(modelBuilder);
            SeedCategories(modelBuilder);
            SeedPies(modelBuilder);

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
                    CustomFileFormat = "txt"
                },
                new()
                {
                    CustomFileId = 2,
                    CustomFileName = "File 2",
                    CustomDisplayName = "File 2",
                    CustomFileData = System.Text.Encoding.UTF8.GetBytes("Bye World!"),
                    ParentFolderId = 2,
                    CustomFileFormat = "txt"
                },
                new()
                {
                    CustomFileId = 3,
                    CustomFileName = "File 3",
                    CustomDisplayName = "File 3",
                    CustomFileData = System.Text.Encoding.UTF8.GetBytes("Hello again!"),
                    ParentFolderId = 2,
                    CustomFileFormat = "txt"
                }
            };

            modelBuilder.Entity<CustomFileDao>().HasData(fileDaos);
        }

        private void SeedPies(ModelBuilder modelBuilder)
        {
            List<PieDao> pies = new List<PieDao>
                    {
                new() {PieId = 1, Name="StÏrawberry Pie", Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", CategoryId = 1,ImageUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypie.jpg", InStock=true, IsPieOfTheWeek=false, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/strawberrypiesmall.jpg"},
                new() {PieId = 2, Name="Cheese cake", Price=18.95M, ShortDescription="Lorem Ipsum", LongDescription="Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", CategoryId = 1,ImageUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/cheesecake.jpg", InStock=true, IsPieOfTheWeek=false, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/cheesecakesmall.jpg"},
                new() {PieId = 3, Name="Rhubarb Pie", Price=15.95M, ShortDescription="Lorem Ipsum", LongDescription="Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", CategoryId = 1,ImageUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/rhubarbpie.jpg", InStock=true, IsPieOfTheWeek=true, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/rhubarbpiesmall.jpg"},
                new() {PieId = 4, Name="Pumpkin Pie", Price=12.95M, ShortDescription="Lorem Ipsum", LongDescription="Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", CategoryId = 1,ImageUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/seasonal/pumpkinpie.jpg", InStock=true, IsPieOfTheWeek=true, ImageThumbnailUrl="https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/seasonal/pumpkinpiesmall.jpg"}
                    };

            modelBuilder.Entity<PieDao>().HasData(pies);
        }

        private void SeedCategories(ModelBuilder modelBuilder)
        {
            List<CategoryDao> categories = new List<CategoryDao>
            {
                new() { CategoryId = 1, CategoryName = "Category 1" },
                new() { CategoryId = 2, CategoryName = "Category 2" },
                new() { CategoryId = 3, CategoryName = "Category 3" }
            };

            modelBuilder.Entity<CategoryDao>().HasData(categories);
        }
    }
}