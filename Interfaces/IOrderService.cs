using NikePro.Data;

namespace NikePro.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(Order order);
        Task EditOrder(Order order);
        Task<List<Order>> GetOrdersByUserId(string Id);
        Task<List<Order>> GetOrdersPending();
        Task<string> GetFIOOrderCreator(Order order);
        Task<Order> GetOrderById(int Id);
    }
}
