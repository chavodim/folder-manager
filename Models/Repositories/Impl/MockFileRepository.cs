namespace FolderManagerApp.Models.Repositories.Impl

{
    public class MockFileRepository : IFileRepository
    {
        private readonly List<CustomFile> _files = new();

        public MockFileRepository()
        {
            _files.Add(new CustomFile
            {
                FileId = 1,
                FileName = "File 1",
                FileData = System.Text.Encoding.UTF8.GetBytes("Hello World!"),
                FilePath = "C:\\Users\\User\\Desktop\\File 1.txt",
            });
            _files.Add(new CustomFile
            {
                FileId = 2,
                FileName = "File 2",
                FileData = System.Text.Encoding.UTF8.GetBytes("Bye World!"),
                FilePath = "C:\\Users\\User\\Desktop\\File 2.txt",
            });
            _files.Add(new CustomFile
            {
                FileId = 3,
                FileName = "File 3",
                FileData = System.Text.Encoding.UTF8.GetBytes("Hello again!"),
                FilePath = "C:\\Users\\User\\Desktop\\File 3.txt",
            });
        }

        public List<CustomFile> Files => _files;

        IEnumerable<CustomFile> IFileRepository.Files => _files;

        public void DeleteFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public byte[]? GetFile(string filePath)
        {
            throw new NotImplementedException();
        }

        public void SaveFile(string filePath, byte[] fileData)
        {
        }
    }
}
