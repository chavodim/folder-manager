using System.ComponentModel.DataAnnotations;

namespace FolderManagerApp.ViewModels
{
    public class FolderCreateView
    {

        public int FolderId { get; set; }
        [Required]
        public string FolderName { get; set; } = string.Empty;

    }
}
