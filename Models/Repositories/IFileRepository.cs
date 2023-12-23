namespace FolderManagerApp.Models.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<CustomFile> Files { get; }
        void SaveFile(string filePath, byte[] fileData);
        byte[]? GetFile(string filePath);
        void DeleteFile(string filePath);
    }
}
