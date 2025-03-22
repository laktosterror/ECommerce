using ECommerce.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ECommerceDbContext _context;

    public OrderRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null) return false;
        _context.Orders.Remove(order);
        return await _context.SaveChangesAsync() > 0;
    }
}

