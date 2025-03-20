using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public interface ICustomerRepository
{
    Task<bool> CreateAsync(Customer customer);
    Task<Customer?> GetByIdAsync(Guid id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<bool> UpdateByIdAsync(Customer customer);
    Task<bool> DeleteByIdAsync(Guid id);
    // Task<List<Product>> SearchProductsAsync(string searchTerm);
}