using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public interface IOrderRepository
{
    Task<bool> CreateAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task<bool> UpdateAsync(Order order);
    Task<bool> DeleteByIdAsync(Guid id);
}
