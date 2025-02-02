using NikePro.Data;

namespace NikePro.Interfaces
{
    public interface ICartService
    {
        Task<Cart> GetCartByClientId(int clientId);
        Task<Cart> GetCartByUserId(string userId);
        Task CreateCart(Cart cart);
        Task EditCart(Cart cart);
        Task<List<Product>> GetProductsFromCart(Cart cart);
        Task DeleteProductFromCart(Cart cart, Product product);
    }
}
