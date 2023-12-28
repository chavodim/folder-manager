using System.ComponentModel.DataAnnotations;

namespace FolderManagerApp.Models
{
    public class CategoryDao
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<PieDao>? Pies { get; set; }
    }
}
