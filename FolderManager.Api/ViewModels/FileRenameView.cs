using System.ComponentModel.DataAnnotations;

namespace FolderManagerApp.ViewModels
{
    public class FileRenameView : ParentFolderLinkView
    {
        public int FileId { get; set; }

        [Required(ErrorMessage = "Display name cannot be empty.")]
        [Display(Name = "New display Name")]
        [StringLength(50)]
        public string NewDisplayName { get; set; } = string.Empty;

        [Required(ErrorMessage = "File name cannot be empty.")]
        [Display(Name = "New file Name")]
        [StringLength(50)]
        public string NewFileName { get; set; } = string.Empty;
    }
}
