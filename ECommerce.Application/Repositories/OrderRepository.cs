using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = new();

    public Task<bool> CreateAsync(Order order)
    {
        _orders.Add(order);
        return Task.FromResult(true);
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        var order = _orders.SingleOrDefault(o => o.Id == id);
        return Task.FromResult(order);
    }

    public Task<IEnumerable<Order>> GetAllAsync()
    {
        return Task.FromResult(_orders.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Order order)
    {
        var orderIndex = _orders.FindIndex(o => o.Id == order.Id);
        if (orderIndex == -1) return Task.FromResult(false);
        _orders[orderIndex] = order;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _orders.RemoveAll(o => o.Id == id);
        var orderRemoved = removedCount > 0;
        return Task.FromResult(orderRemoved);
    }
}