namespace FolderManagerApp.ViewModels
{
    public class FolderRenameView
    {
        public int FolderId { get; set; }
        public string NewName { get; set; } = string.Empty;

        public int ParentFolderId { get; set; }
    }
}
