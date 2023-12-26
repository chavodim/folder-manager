namespace FolderManagerApp.Models.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<CustomFile> Files { get; }

        Folder Folder { get; }

        void SaveFile(string filePath, byte[] fileData);
        byte[]? GetFile(string filePath);
        void DeleteFile(string filePath);
    }
}
