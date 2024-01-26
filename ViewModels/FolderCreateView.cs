using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.ViewModels
{
    public class FolderCreateView : FolderLinkView
    {
        [Required(ErrorMessage ="Folder name cannot be empty.")]
        [Display(Name ="Folder Name")]
        [StringLength(50)]
        public string FolderName { get; set; } = string.Empty;

    }
}
