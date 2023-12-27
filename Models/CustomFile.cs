namespace FolderManagerApp.Models
{
    public class CustomFile
    {
        public int CustomFileId { get; set; }

        public string CustomFileName { get; set; } = string.Empty;

        public byte[] CustomFileData { get; set; } = new byte[0];

        public Folder ParentFolder { get; set; } = new Folder();

        public string CustomFileFormat { get; set; } = string.Empty;

        public string CustomFilePath
        {
            get { return ParentFolder + CustomFileName + "." + CustomFileFormat; }
        }

    }
}