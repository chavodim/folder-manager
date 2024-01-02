namespace FolderManagerApp.Models
{
    public class ShoppingCartItem
    {

        public int ShoppingCartItemId { get; set; }

        public PieDao Pie { get; set; } = default!;

        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
        
    }
}
