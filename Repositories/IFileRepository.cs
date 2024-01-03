using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<CustomFileDao> Files { get; }
        void SaveFile(CustomFileDao customFile);
        CustomFileDao? GetFileById(int fileId);
        List<CustomFileDao>? GetFilesByFolderId(int folderId);

        void RenameFile(CustomFileDao customFileDao, string newFileName, string newDisplayName);
        void DeleteFile(CustomFileDao customFileDao);
    }
}
