using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces;

namespace NikePro.Services
{
    public class OrderServices : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderServices(ApplicationDbContext context) { _context = context; }

        public async Task CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            _context.SaveChanges();
        }

        public async Task EditOrder(Order order)
        {
                _context.Attach(order!).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine($"Concurrency error occurred: {ex.Message}");
                    throw;
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Database update error occurred: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    throw;
                }
        }

        public async Task<string> GetFIOOrderCreator(Order order)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u=>u.Id == order.Client.UserId);

            if (user == null)
            {
                return "Пользователь не найден";
            }

            return $"{user.Surname} {user.Name} {user.Patronymic}";
        }

        public async Task<Order> GetOrderById(int Id)
        {
            return await _context.Orders.Include(e=>e.OrderStatus).Include(e => e.OrderItems).ThenInclude(ei => ei.Product).FirstOrDefaultAsync(o=>o.OrderId == Id);
        }

        public async Task<List<Order>> GetOrdersByUserId(string Id)
        {
            var client =  await _context.Clients.FirstOrDefaultAsync(e=>e.UserId == Id);
            return await _context.Orders.Include(o=>o.OrderStatus).Include(e=>e.OrderItems).ThenInclude(ei=>ei.Product).Where(o=>o.ClientId == client.ClientId).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersPending()
        {
            return await _context.Orders
                .Include(o=>o.Client).ThenInclude(oi=>oi.User)
                .Include(e => e.OrderItems).ThenInclude(ei => ei.Product)
                .Where(o => o.OrderStatus.Name == "Собирается" || o.OrderStatus.Name == "Готов к выдаче")
                .ToListAsync();
        }
    }
}
