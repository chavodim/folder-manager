namespace FolderManagerApp.ViewModels
{
    public class FileRenameView
    {
        public int FileId { get; set; }
        public string NewDisplayName { get; set; } = string.Empty;
        public string NewFileName { get; set; } = string.Empty;

        public int FolderId { get; set; }


    }
}
