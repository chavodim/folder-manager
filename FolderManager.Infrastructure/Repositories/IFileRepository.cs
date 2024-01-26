using FolderManagerApp.Models;
using System.Collections.Generic;

namespace FolderManagerApp.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<CustomFile> Files { get; }
        void SaveFile(CustomFile customFile);
        CustomFile? GetFileById(int fileId);
        List<CustomFile>? GetFilesByFolderId(int folderId);

        void RenameFile(CustomFile customFileDao, string newFileName, string newDisplayName);
        void DeleteFile(CustomFile customFileDao);
    }
}
