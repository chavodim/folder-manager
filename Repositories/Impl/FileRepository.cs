using FolderManagerApp.Data;
using FolderManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Repositories.Impl
{
    public class FileRepository : IFileRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public FileRepository(FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public IEnumerable<CustomFileDao> Files
        {
            get
            {
                return _folderManagerDbContext.Files.Include(f => f.ParentFolder);
            }
        }

        public void DeleteFile(CustomFileDao customFileDao)
        {
            _folderManagerDbContext.Remove(customFileDao);
            _folderManagerDbContext.SaveChanges();
        }

        public CustomFileDao? GetFileById(int fileId)
        {
            return _folderManagerDbContext.Files.Include(f => f.ParentFolder).FirstOrDefault(f => f.CustomFileId == fileId);
        }

        public List<CustomFileDao>? GetFilesByFolderId(int folderId)
        {
            return _folderManagerDbContext.Files.Include(f => f.ParentFolder).Where(f => f.ParentFolderId == folderId).ToList();
        }

        public void RenameFile(CustomFileDao customFileDao, string newFileName,string newDisplayName)
        {
            customFileDao.CustomFileName = newFileName;
            customFileDao.CustomDisplayName = newDisplayName;
            _folderManagerDbContext.SaveChanges();
        }

        public void SaveFile(CustomFileDao customFile)
        {
            _folderManagerDbContext.Files.Add(customFile);
            _folderManagerDbContext.SaveChanges();
        }
    }
}