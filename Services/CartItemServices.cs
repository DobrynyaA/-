using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces;

namespace NikePro.Services
{
    public class CartItemServices : ICartItemService
    {
        private readonly ApplicationDbContext _context;
        public CartItemServices(ApplicationDbContext context) { _context = context; }

        public async Task DeleteAllCartItemInCart(Cart cart)
        {

            if (cart == null)
            {
                throw new ArgumentException("Корзина не найдена.");
            }

            var cartItems = _context.CartItems.Where(ci => ci.CartId == cart.CartId);

            _context.CartItems.RemoveRange(cartItems);

            await _context.SaveChangesAsync();
        }

        public async Task EditCartitem(CartItem cartItem)
        {
            _context.Attach(cartItem!).State = EntityState.Modified;
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

        public async Task<CartItem> GetCartItemById(int id)
        {
            return await _context.CartItems.FirstOrDefaultAsync(c => c.CartItemId == id);
        }
    }
}

