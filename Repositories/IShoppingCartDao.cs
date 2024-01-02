namespace FolderManagerApp.Models
{
    public interface IShoppingCartDao
    {
        void AddToCart(PieDao pie);
        int RemoveFromCart(PieDao pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

