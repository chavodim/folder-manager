using System.ComponentModel.DataAnnotations;

namespace FolderManagerApp.Models
{
    public class CustomFileDao
    {
        [Key]
        public int CustomFileId { get; set; }

        public string CustomFileName { get; set; } = string.Empty;
        public string CustomDisplayName { get; set; } = string.Empty;

        public byte[] CustomFileData { get; set; } = new byte[0];

        public int ParentFolderId { get; set; }
        public FolderDao ParentFolder { get; set; }

        public string CustomFileFormat { get; set; } = string.Empty;

        public double CustomFileSize {  get; set; }

        public string CustomFilePath
        {
            get
            {
                return ParentFolder.FolderPathWithoutRoot() + @"\" + CustomFileName + "." + CustomFileFormat;
            }
        }

    }
}