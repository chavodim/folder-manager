using System.ComponentModel.DataAnnotations;

namespace FolderManagerApp.ViewModels
{
    public class FileCreateView
    {

        public int FolderId { get; set; }
        [Required]
        public IFormFile FormFile { get; set; }

    }
}
