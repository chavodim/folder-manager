using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories
{
    public interface IFolderRepository
    {
        IEnumerable<FolderDao> AllFolders { get; }
        FolderDao? GetFolderById(int folderId);
        FolderDao? GetFolderByName(string name);
        List<FolderDao>? GetChildrenFolders(int folderId);
        void CreateFolder(FolderDao folder);
        void UpdateFolder(FolderDao folder);
        void DeleteFolder(FolderDao folder);
    }
}