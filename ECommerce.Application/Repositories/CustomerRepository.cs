using ECommerce.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ECommerceDbContext _context;

    public CustomerRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<bool> UpdateByIdAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return false;
        _context.Customers.Remove(customer);
        return await _context.SaveChangesAsync() > 0;
    }
}
