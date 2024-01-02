using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace FolderManagerApp.Models
{
    public class OrderDetailDao
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PieId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public PieDao Pie { get; set; } = default!;
        public OrderDao Order { get; set; } = default!;
    }
}
