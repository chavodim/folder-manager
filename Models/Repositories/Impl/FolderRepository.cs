
namespace FolderManagerApp.Models.Repositories.Impl
{
    public class FolderRepository : IFolderRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public FolderRepository (FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public IEnumerable<Folder> AllFolders
        {
            get
            {
                return _folderManagerDbContext.Folders;
            }
        }

        public void CreateFolder(Folder folder)
        {
            _folderManagerDbContext.Folders.Add(folder);
            _folderManagerDbContext.SaveChanges();
        }

        public void DeleteFolder(Folder folder)
        {
            var persistedFolder = GetFolderById(folder.FolderId);
            if (persistedFolder != null)
            {
                _folderManagerDbContext.Remove(persistedFolder);
                _folderManagerDbContext.SaveChanges();
            }
        }

        public Folder? GetFolderById(int folderId)
        {
            return _folderManagerDbContext.Folders.FirstOrDefault(folder => folder.FolderId == folderId);
        }

        public void UpdateFolder(Folder folder)
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