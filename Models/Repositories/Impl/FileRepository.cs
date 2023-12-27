
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Models.Repositories.Impl
{
    public class FileRepository : IFileRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public FileRepository(FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public IEnumerable<CustomFile> Files
        {
            get
            {
                return _folderManagerDbContext.Files.Include(f => f.ParentFolder);
            }
        }

        public void DeleteFile(int fileId)
        {
            var persistedFile = GetFileById(fileId);
            if (persistedFile != null)
            {
                _folderManagerDbContext.Remove(persistedFile);
                _folderManagerDbContext.SaveChanges();
            }
        }

        public CustomFile? GetFileById(int fileId)
        {
            return _folderManagerDbContext.Files.FirstOrDefault(f => f.CustomFileId == fileId);
        }

        public void SaveFile(CustomFile customFile)
        {
            _folderManagerDbContext.Files.Add(customFile);
            _folderManagerDbContext.SaveChanges();
        }
    }
}