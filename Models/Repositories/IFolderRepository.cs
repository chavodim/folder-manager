namespace FolderManagerApp.Models.Repositories
{
    public interface IFolderRepository
    {
        IEnumerable<Folder> AllFolders { get; }
        Folder? GetFolderById(int folderId);
        void CreateFolder(Folder folder);
        void UpdateFolder(Folder folder);
        void DeleteFolder(Folder folder);
    }
}