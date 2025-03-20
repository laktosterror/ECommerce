using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<bool> CreateAsync(Product product)
    {
        _products.Add(product);
        return Task.FromResult(true);
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        var product = _products.SingleOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task<IEnumerable<Product>> GetAllAsync()
    {
        return Task.FromResult(_products.AsEnumerable());
    }

    public Task<bool> UpdateByIdAsync(Product product)
    {
        var productIndex = _products.FindIndex(p => p.Id == product.Id);
        if (productIndex == -1) return Task.FromResult(false);
        _products[productIndex] = product;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _products.RemoveAll(p => p.Id == id);
        var productRemoved = removedCount > 0;
        return Task.FromResult(productRemoved);
    }

    // public async Task<List<Product>> SearchProductsAsync(string searchTerm)
    // {
    //     return await _context.Products
    //         .Where(p => p.ProductName.Contains(searchTerm) || p.ProductId.ToString().Contains(searchTerm))
    //         .ToListAsync();
    // }
}