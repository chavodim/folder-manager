using FolderManagerApp.Data;
using FolderManagerApp.Models;

namespace FolderManager.Infrastructure
{
    public class FolderManagerDbContextSeed(FolderManagerDbContext folderManagerDbContext)
    {

        private readonly FolderManagerDbContext folderManagerDbContext = folderManagerDbContext;

        public void Seed()
        {
            if (!folderManagerDbContext.Folders.Any())
            {
                string rootFolderName = "root";
                Folder rootFolder = new()
                {
                    FolderName = rootFolderName,
                    FolderPath = rootFolderName
                };
                folderManagerDbContext.Folders.Add(rootFolder);
                folderManagerDbContext.SaveChanges();

                folderManagerDbContext.Folders.Add(
                    new()
                    {
                        FolderName = "files",
                        FolderPath = rootFolder.FolderName + @"\files",
                        ParentFolderId = rootFolder.FolderId
                    }); ;
                folderManagerDbContext.SaveChanges();
            }

            if (!folderManagerDbContext.Files.Any()) {

                var filesFolderId = folderManagerDbContext.Folders
                            .Where(f => f.FolderName == "files")
                            .Select(f => f.FolderId)
                            .FirstOrDefault();

                folderManagerDbContext.AddRange(
                    new CustomFile()
                    {
                        CustomFileName = "File 1",
                        CustomDisplayName = "File 1",
                        CustomFileData = System.Text.Encoding.UTF8.GetBytes("Hello World!"),
                        ParentFolderId = filesFolderId,
                        CustomFileFormat = "txt",
                        CustomFileSize = 1000
                    },
                    new CustomFile()
                    {
                        CustomFileName = "File 2",
                        CustomDisplayName = "File 2",
                        CustomFileData = System.Text.Encoding.UTF8.GetBytes("Bye World!"),
                        ParentFolderId = filesFolderId,
                        CustomFileFormat = "txt",
                        CustomFileSize = 1000
                    },
                    new CustomFile()
                    {
                        CustomFileName = "File 3",
                        CustomDisplayName = "File 3",
                        CustomFileData = System.Text.Encoding.UTF8.GetBytes("Hello again!"),
                        ParentFolderId = filesFolderId,
                        CustomFileFormat = "txt",
                        CustomFileSize = 1000
                    });
                folderManagerDbContext.SaveChanges();
            }
        }
    }
}
