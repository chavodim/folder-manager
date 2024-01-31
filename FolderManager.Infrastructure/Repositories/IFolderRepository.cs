using FolderManager.Infrastructure.Repositories;
using FolderManagerApp.Models;
using System.Collections.Generic;

namespace FolderManagerApp.Repositories
{
    public interface IFolderRepository : IRepository<Folder>
    {
        Folder? GetFolderByIdWithFiles(int folderId);
        List<Folder>? GetChildrenFolders(int folderId);
        void RenameFolder(Folder folderDao, string folderName);
    }
}