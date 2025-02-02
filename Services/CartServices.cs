using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces;

namespace NikePro.Services
{
    public class CartServices : ICartService
    {
        private readonly ApplicationDbContext _context;
        public CartServices(ApplicationDbContext context) { _context = context; }

        public async Task CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteProductFromCart(Cart cart, Product product)
        {
            //var newCart = cart.Items.Where(p => p.ProductId != product.ProductId).FirstOrDefault();
            var CartItem = await _context.CartItems.Where(p => p.CartId == cart.CartId && p.ProductId == product.ProductId).FirstOrDefaultAsync();
            cart.Items.Remove(CartItem);
            _context.Attach(cart!).State = EntityState.Modified;
            if (CartItem != null)
                _context.CartItems.Remove(CartItem);
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

        public async Task EditCart(Cart cart)
        {
            _context.Attach(cart!).State = EntityState.Modified;
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

        public async Task<Cart> GetCartByClientId(int clientId)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.Clientid == clientId);
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(x => x.UserId == userId);
            return await _context.Carts
            .Include(c => c.Items)
            .ThenInclude(ci => ci.Product) 
            .FirstOrDefaultAsync(c => c.Clientid == client.ClientId);
        }

        public async Task<List<Product>> GetProductsFromCart(Cart cart)
        {
            if (cart?.Items == null || !cart.Items.Any())
            {
                return new List<Product>();
            }
            return cart.Items.Select(item => item.Product).ToList();
        }
    }
}
