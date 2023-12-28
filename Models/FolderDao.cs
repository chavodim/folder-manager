using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace FolderManagerApp.Models
{
    public class FolderDao
    {
        [Key]
        public int FolderId { get; set; }

        public string FolderName { get; set; } = string.Empty;

        public List<CustomFileDao>? Files { get; set; }

        public int? ParentFolderId { get; set; }

        public FolderDao? ParentFolder { get; set; }

        public ICollection<FolderDao>? Children { get; set; }


    }
}