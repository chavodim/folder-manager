using FolderManagerApp.Data;
using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories.Impl
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FolderManagerDbContext _folderManagerDbContext;
        private readonly IShoppingCartDao _shoppingCartDao;

        public OrderRepository(FolderManagerDbContext folderManagerDbContext, IShoppingCartDao shoppingCartDao)
        {
            _folderManagerDbContext = folderManagerDbContext;
            _shoppingCartDao = shoppingCartDao;
        }

        public void CreateOrder(OrderDao orderDao)
        {
            orderDao.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? items = _shoppingCartDao.ShoppingCartItems;
            orderDao.OrderTotal = _shoppingCartDao.GetShoppingCartTotal();

            orderDao.OrderDetails = new List<OrderDetailDao>();

            foreach (ShoppingCartItem? item in items)
            {
                var OrderDetails = new OrderDetailDao
                {
                    Amount = item.Amount,
                    PieId = item.Pie.PieId,
                    Price = item.Pie.Price
                };

                orderDao.OrderDetails.Add(OrderDetails);
            }

            _folderManagerDbContext.Orders.Add(orderDao);

            _folderManagerDbContext.SaveChanges();
        }
    }
}
