using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.ViewModels
{
    public class FolderCreateView
    {

        public int CurrentFolderId { get; set; }

        public string CurrentFolderName { get; set; }

        [Required(ErrorMessage ="Folder name cannot be empty.")]
        [Display(Name ="New Folder Name")]
        [StringLength(50)]
        public string FolderName { get; set; } = string.Empty;

    }
}
