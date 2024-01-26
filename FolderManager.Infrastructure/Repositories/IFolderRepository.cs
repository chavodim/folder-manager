using FolderManagerApp.Models;
using System.Collections.Generic;

namespace FolderManagerApp.Repositories
{
    public interface IFolderRepository
    {
        IEnumerable<Folder> AllFolders { get; }
        Folder? GetFolderById(int folderId);
        Folder? GetFolderByName(string name);
        List<Folder>? GetChildrenFolders(int folderId);
        void CreateFolder(Folder folder);
        void DeleteFolder(int folderId);
        void RenameFolder(Folder folderDao, string folderName);
    }
}