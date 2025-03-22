using ECommerce.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ECommerceDbContext _context;

    public ProductRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<bool> UpdateByIdAsync(Product product)
    {
        _context.Products.Update(product);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;
        _context.Products.Remove(product);
        return await _context.SaveChangesAsync() > 0;
    }
}
