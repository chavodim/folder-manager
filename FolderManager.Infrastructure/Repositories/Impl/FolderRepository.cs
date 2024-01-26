using FolderManagerApp.Data;
using FolderManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Repositories.Impl
{
    public class FolderRepository : IFolderRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public FolderRepository(FolderManagerDbContext folderManagerDbContext)
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



        public List<Folder>? GetChildrenFolders(int folderId)
        {
            return _folderManagerDbContext.Folders.Where(f => f.ParentFolderId == folderId).ToList();
        }

        public Folder? GetFolderById(int folderId)
        {
            return _folderManagerDbContext.Folders.FirstOrDefault(folder => folder.FolderId == folderId);
        }

        public Folder? GetFolderByName(string name)
        {
            return _folderManagerDbContext.Folders.FirstOrDefault(folder => folder.FolderName == name);
        }

        public void RenameFolder(Folder folder, string newName)
        {
            folder.FolderPath = folder.FolderPath.Replace(folder.FolderName, newName);
            folder.FolderName = newName;
            _folderManagerDbContext.SaveChanges();
        }

        public void DeleteFolder(int folderId)
        {
            using (var transaction = _folderManagerDbContext.Database.BeginTransaction())
            {
                try
                {
                    RecursiveDelete(folderId);
                    _folderManagerDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        private void RecursiveDelete(int folderId)
        {
            var folder = _folderManagerDbContext.Folders
                .Include(f => f.Files)
                .Include(f => f.ChildrenFolders)
                .FirstOrDefault(f => f.FolderId == folderId);

            if (folder == null)
            {
                return;
            }

            if (folder.Files != null)
            {
                foreach (var item in folder.Files)
                {
                    _folderManagerDbContext.Remove(item);
                }
            }

            if (folder.ChildrenFolders != null)
            {
                foreach (var childFolder in folder.ChildrenFolders)
                {
                    RecursiveDelete(childFolder.FolderId);
                }
            }

            _folderManagerDbContext.Folders.Remove(folder);
        }
    }
}