using System.ComponentModel.DataAnnotations;

namespace FolderManagerApp.ViewModels
{
    public class FileCreateView : FolderLinkView
    {
        [Required(ErrorMessage = "Please enter a display name for the file")]
        [Display(Name = "File Display Name")]
        [StringLength(50)]
        public string DisplayName { get; set; } = string.Empty;

        [Required(ErrorMessage ="No file was uploaded")]
        [Display(Name = "Upload File")]
        public IFormFile FormFile { get; set; }
    }
}
