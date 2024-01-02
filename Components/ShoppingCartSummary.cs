using FolderManagerApp.Models;
using FolderManagerApp.Repositories.Impl;
using FolderManagerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCartDao _shoppingCartDao;

        public ShoppingCartSummary(IShoppingCartDao shoppingCartDao)
        {
            _shoppingCartDao = shoppingCartDao;
        }

        public IViewComponentResult Invoke()
        {
            //var items = new List<ShoppingCartItem>() { new ShoppingCartItem(), new ShoppingCartItem() };
            //_shoppingCartDao.ShoppingCartItems = items;
            _shoppingCartDao.ShoppingCartItems = _shoppingCartDao.GetShoppingCartItems();

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCartDao, _shoppingCartDao.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
    }
}
