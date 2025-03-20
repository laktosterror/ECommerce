using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public interface IProductRepository
{
    Task<bool> CreateAsync(Product product);
    Task<Product?> GetByIdAsync(Guid id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<bool> UpdateByIdAsync(Product product);
    Task<bool> DeleteByIdAsync(Guid id);

    // Task<List<Product>> SearchProductsAsync(string searchTerm);
}