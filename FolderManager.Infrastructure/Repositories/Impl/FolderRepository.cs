using FolderManager.Infrastructure.Repositories.Impl;
using FolderManagerApp.Data;
using FolderManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Repositories.Impl
{
    public class FolderRepository : GenericRepository<Folder>, IFolderRepository
    {
        public FolderRepository(FolderManagerDbContext folderManagerDbContext) : base(folderManagerDbContext) 
        {
        }

        public Folder? GetFolderByIdWithFiles(int folderId)
        {
            return folderManagerDbContext.Folders
                .Include(f => f.Files)
                .FirstOrDefault(f => f.FolderId == folderId);
        }

        public List<Folder>? GetChildrenFolders(int folderId)
        {
            return folderManagerDbContext.Folders
                .Where(f => f.ParentFolderId == folderId)
                .ToList();
        }

        public void RenameFolder(Folder folder, string newName)
        {
            folder.FolderPath = folder.FolderPath.Replace(folder.FolderName, newName);
            folder.FolderName = newName;
            base.Update(folder);
        }
    }
}