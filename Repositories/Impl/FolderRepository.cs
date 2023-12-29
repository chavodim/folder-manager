using FolderManagerApp.Data;
using FolderManagerApp.Models;
using FolderManagerApp.Repositories;

namespace FolderManagerApp.Repositories.Impl
{
    public class FolderRepository : IFolderRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public FolderRepository(FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public IEnumerable<FolderDao> AllFolders
        {
            get
            {
                return _folderManagerDbContext.Folders;
            }
        }

        public void CreateFolder(FolderDao folder)
        {
            _folderManagerDbContext.Folders.Add(folder);
            _folderManagerDbContext.SaveChanges();
        }

        public void DeleteFolder(FolderDao folder)
        {
            var persistedFolder = GetFolderById(folder.FolderId);
            if (persistedFolder != null)
            {
                _folderManagerDbContext.Remove(persistedFolder);
                _folderManagerDbContext.SaveChanges();
            }
        }

        public List<FolderDao>? GetChildrenFolders(int folderId)
        {
            return _folderManagerDbContext.Folders.Where(f => f.ParentFolderId == folderId).ToList();
        }

        public FolderDao? GetFolderById(int folderId)
        {
            return _folderManagerDbContext.Folders.FirstOrDefault(folder => folder.FolderId == folderId);
        }

        public FolderDao? GetFolderByName(string name)
        {
            return _folderManagerDbContext.Folders.FirstOrDefault(folder => folder.FolderName == name);
        }

        public void UpdateFolder(FolderDao folder)
        {
            var persistedFolder = GetFolderById(folder.FolderId);
            if (persistedFolder != null)
            {
                persistedFolder.FolderName = folder.FolderName;
                _folderManagerDbContext.SaveChanges();
            }
        }
    }
}