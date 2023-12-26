namespace FolderManagerApp.Models
{
    public class CustomFile
    {
        public int FileId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public byte[] FileData { get; set; } = new byte[0];

        public string ParentFolder { get; set; } = string.Empty;

        public string FileFormat { get; set; } = string.Empty;

        public string FilePath
        {
            get { return ParentFolder + FileName + "." + FileFormat; }
        }

    }
}