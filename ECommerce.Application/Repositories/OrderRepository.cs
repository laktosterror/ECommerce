using System.Net.Security;
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
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetAllByCustomerId(Guid id)
    {
        return await _context.Orders
            .Where(o => o.CustomerId == id)
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _context.Orders
            .Include(o => o.Customer)
            .Include(o => o.OrderProducts)
            .ThenInclude(op => op.Product)
            .ToListAsync();
    }

    public async Task<bool> UpdateAsync(Order order)
    {
        // var existingOrder = await _context.Orders
        //     .Include(o => o.Customer)
        //     .Include(o => o.OrderProducts)
        //     .ThenInclude(op => op.Product)
        //     .FirstOrDefaultAsync(o => o.Id ==order.Id);
        //
        // if (existingOrder == null)
        // {
        //     return false;
        // }
        //
        // existingOrder.Status = order.Status;
        // existingOrder.OrderProducts = order.OrderProducts;
        //
        // foreach (var orderProduct in order.OrderProducts)
        // {
        //     
        // }
        
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

