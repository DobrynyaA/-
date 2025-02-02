using NikePro.Data;

namespace NikePro.Interfaces
{
    public interface ICartItemService
    {
        Task EditCartitem(CartItem cartItem);
        Task<CartItem> GetCartItemById(int id);
        Task DeleteAllCartItemInCart(Cart cart);
    }
}
