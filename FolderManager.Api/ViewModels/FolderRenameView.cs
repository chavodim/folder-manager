namespace FolderManagerApp.ViewModels
{
    public class FolderRenameView : ParentFolderLinkView
    {
        public int FolderId { get; set; }
        public string NewName { get; set; } = string.Empty;

    }
}
