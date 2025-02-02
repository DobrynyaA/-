using NikePro.Data;

namespace NikePro.Interfaces
{
    public interface IOrderStatus
    {
        Task<OrderStatus> GetOrderStatusByNameAsync(string name);
    }
}
