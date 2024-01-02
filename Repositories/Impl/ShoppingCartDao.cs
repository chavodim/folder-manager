using FolderManagerApp.Data;
using FolderManagerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderManagerApp.Repositories.Impl
{
    public class ShoppingCartDao : IShoppingCartDao
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCartDao(FolderManagerDbContext folderManagerDbContext)
        {
            _folderManagerDbContext = folderManagerDbContext;
        }

        public static ShoppingCartDao GetCart(IServiceProvider serviceProvider)
        {
            ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            FolderManagerDbContext folderManagerDbContext = serviceProvider.GetService<FolderManagerDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCartDao(folderManagerDbContext) { ShoppingCartId = cartId };
        }

        public void AddToCart(PieDao pie)
        {
            var shoppingCartItem =
                _folderManagerDbContext.ShoppingCartItems
                .SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };
                _folderManagerDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _folderManagerDbContext.SaveChanges();
        }

        public int RemoveFromCart(PieDao pie)
        {
            var shoppingCartItem =
                _folderManagerDbContext.ShoppingCartItems
                .SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _folderManagerDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _folderManagerDbContext.SaveChanges();
            return localAmount;

        }

        public void ClearCart()
        {
            var cartItems = _folderManagerDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _folderManagerDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _folderManagerDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _folderManagerDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Pie)
                           .ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _folderManagerDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }

    }
}
