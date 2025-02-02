using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces;

namespace NikePro.Services
{
    public class OrderStatusServices : IOrderStatus
    {
        private readonly ApplicationDbContext _context;
        public OrderStatusServices(ApplicationDbContext context) { _context = context; }

        public async Task<OrderStatus> GetOrderStatusByNameAsync(string name)
        {
            return await _context.OrderStatuses.FirstOrDefaultAsync(os=>os.Name == name);
        }
    }
}
