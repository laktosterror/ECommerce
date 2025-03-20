using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public interface IProductRepository
{
    Task<bool> CreateAsync(Product product);
    Task<bool> UpdateByIdAsync(Product product);
    Task<bool> DeleteByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    // Task<List<Product>> SearchProductsAsync(string searchTerm);
}
