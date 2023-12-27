namespace FolderManagerApp.Models.Repositories
{
    public interface IFileRepository
    {
        IEnumerable<CustomFile> Files { get; }
        void SaveFile(CustomFile customFile);
        CustomFile? GetFileById(int fileId);
        void DeleteFile(int fileId);
    }
}
