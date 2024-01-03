using System.ComponentModel.DataAnnotations;

namespace FolderManagerApp.ViewModels
{
    public class FileCreateView
    {

        public int FolderId { get; set; }

        public string DisplayName { get; set; } = string.Empty;

        [Required]
        public IFormFile FormFile { get; set; }

    }
}
