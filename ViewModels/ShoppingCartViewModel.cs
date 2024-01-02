using FolderManagerApp.Models;
using FolderManagerApp.Repositories.Impl;

namespace FolderManagerApp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IShoppingCartDao ShoppingCartDao { get; }
        public decimal ShoppingCartTotal { get; }

        public ShoppingCartViewModel(IShoppingCartDao shoppingCartDao, decimal shoppingCartTotal) 
        {
            ShoppingCartDao = shoppingCartDao;
            ShoppingCartTotal = shoppingCartTotal;
        }
    }
}
