using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllAsync();
    Task<bool> UpdateByIdAsync(Guid id, User user);
    Task<bool> DeleteByIdAsync(Guid id);
}