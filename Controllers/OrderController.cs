using FolderManagerApp.Models;
using FolderManagerApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FolderManagerApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCartDao _shoppingCartDao;

        public OrderController(IOrderRepository orderRepository, IShoppingCartDao shoppingCartDao)
        {
            _orderRepository = orderRepository;
            _shoppingCartDao = shoppingCartDao;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(OrderDao order)
        {
            var items = _shoppingCartDao.GetShoppingCartItems();
            _shoppingCartDao.ShoppingCartItems = items;

            if (items.Count == 0) 
            {
                ModelState.AddModelError("", "Your cart is empty, add some items first.");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCartDao.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
