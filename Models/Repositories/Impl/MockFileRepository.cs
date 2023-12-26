namespace FolderManagerApp.Models.Repositories.Impl

{
    public class MockFileRepository : IFileRepository
    {
        private readonly Folder _folder = new();
        private readonly List<CustomFile> _files = new();

        public MockFileRepository()
        {
            _files = AddFiles();
            _folder = new Folder{
                FolderId = 1,
                FolderName = "wwwroot/",
                Files = _files
            };
        }

        private List<CustomFile> AddFiles()
        {
            List<CustomFile> list = new();
            list.Add(new CustomFile
            {
                FileId = 1,
                FileName = "File 1",
                FileData = System.Text.Encoding.UTF8.GetBytes("Hello World!"),
                ParentFolder = "/files/",
                FileFormat = "txt"
            });
            list.Add(new CustomFile
            {
                FileId = 2,
                FileName = "File 2",
                FileData = System.Text.Encoding.UTF8.GetBytes("Bye World!"),
                ParentFolder = "/files/",
                FileFormat = "txt"
            });
            list.Add(new CustomFile
            {
                FileId = 3,
                FileName = "File 3",
                FileData = System.Text.Encoding.UTF8.GetBytes("Hello again!"),
                ParentFolder = "/files/",
                FileFormat = "txt"
            });
            return list;
        }

        public Folder Folder => _folder;

        IEnumerable<CustomFile> IFileRepository.Files => throw new NotImplementedException();

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
