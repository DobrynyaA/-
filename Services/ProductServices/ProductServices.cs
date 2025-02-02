using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NikePro.Data;
using NikePro.Interfaces.ProductInterfaces;

namespace NikePro.Services.ProductServices
{
    public class ProductServices : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddProductAsync(Product product)
        {
             await _context.AddAsync(product);
            _context.SaveChanges();
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
            if (product != null)
            {
                _context.Remove(product); 
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task EditProductAsync(Product product)
        {
            _context.Attach(product!).State = EntityState.Modified;
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

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
        }
        public async Task<List<Product>> GetProductListByCategoriesAsync(int productTypeId)
        {
            return await _context.Products.Where(x=>x.ProductTypeId == productTypeId).ToListAsync();
        }
    }
}
