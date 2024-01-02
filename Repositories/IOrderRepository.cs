using FolderManagerApp.Models;

namespace FolderManagerApp.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(OrderDao order);
    }
}
