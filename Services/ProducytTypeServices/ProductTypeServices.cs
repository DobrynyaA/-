using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces.ProductTypeInterfaces;

namespace NikePro.Services.ProducytTypeServices
{
    public class ProductTypeServices : IProductTypeService
    {
        private readonly ApplicationDbContext _context;
        public ProductTypeServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProductTypeAsync(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductTypeAsync(int productTypeId)
        {
            var productType = await _context.ProductTypes.FirstOrDefaultAsync(x => x.Id == productTypeId);
            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();
        }

        public async Task EditProductTypeAsync(ProductType productType)
        {
            _context.Attach(productType!).State = EntityState.Modified;
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

        public async Task<List<ProductType>> GetAllProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int productTypeId)
        {
            return _context.ProductTypes.FirstOrDefault(x => x.Id == productTypeId);
        }
    }
}
