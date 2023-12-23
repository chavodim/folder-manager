namespace FolderManagerApp.Models
{
    public class Folder
    {
        public int FolderId { get; set; }

        public string FolderName { get; set; } = string.Empty;

        public List<CustomFile>? Files { get; set; }
    }
}