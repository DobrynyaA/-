using NikePro.Data;

namespace NikePro.Interfaces.ProductInterfaces
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductListByCategoriesAsync(int productTypeId);
        Task EditProductAsync(Product productT);
        Task DeleteProductAsync(int productId);
        Task<Product> GetProductByIdAsync(int productId);
    }
}
