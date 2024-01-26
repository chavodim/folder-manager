using FolderManager.Infrastructure.Repositories.Impl;
using FolderManagerApp.Data;
using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories.Impl
{
    public class FolderRepository : GenericRepository<Folder>, IFolderRepository
    {
        public FolderRepository(FolderManagerDbContext folderManagerDbContext) : base(folderManagerDbContext) 
        {
        }

        public List<Folder>? GetChildrenFolders(int folderId)
        {
            return folderManagerDbContext.Folders.Where(f => f.ParentFolderId == folderId).ToList();
        }

        public void RenameFolder(Folder folder, string newName)
        {
            folder.FolderPath = folder.FolderPath.Replace(folder.FolderName, newName);
            folder.FolderName = newName;
            base.Update(folder);
        }
    }
}