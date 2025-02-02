using NikePro.Data;

namespace NikePro.Interfaces.ProductTypeInterfaces
{
    public interface IProductTypeService
    {
        Task AddProductTypeAsync(ProductType productType);
        Task<List<ProductType>> GetAllProductTypesAsync();
        Task EditProductTypeAsync(ProductType productType);
        Task DeleteProductTypeAsync(int productTypeId);
        Task<ProductType> GetProductTypeByIdAsync(int productTypeId);
    }


}
