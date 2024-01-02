using FolderManagerApp.Data;
using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Repositories.Impl
{
    public class FolderRepository : IFolderRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;
        private readonly IFileRepository _fileRepository;

        public FolderRepository(FolderManagerDbContext folderManagerDbContext, IFileRepository fileRepository)
        {
            _folderManagerDbContext = folderManagerDbContext;
            _fileRepository = fileRepository;
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

        //TODO written with ChatGPT - review it
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

            if (folder == null || folder.Files == null)
            {
                return;
            }

            foreach (var file in folder.Files.ToList())
            {
                _fileRepository.DeleteFile(file.CustomFileId);
            }

            foreach (var childFolder in folder.ChildrenFolders.ToList())
            {
                RecursiveDelete(childFolder.FolderId);
            }

            _folderManagerDbContext.Folders.Remove(folder);
        }
    }
}