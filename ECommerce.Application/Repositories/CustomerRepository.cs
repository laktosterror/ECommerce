using ECommerce.Application.Models;

namespace ECommerce.Application.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customers = new();

    public Task<bool> CreateAsync(Customer customer)
    {
        _customers.Add(customer);
        return Task.FromResult(true);
    }

    public Task<Customer?> GetByIdAsync(Guid id)
    {
        var customer = _customers.SingleOrDefault(c => c.Id == id);
        return Task.FromResult(customer);
    }

    public Task<IEnumerable<Customer>> GetAllAsync()
    {
        return Task.FromResult(_customers.AsEnumerable());
    }

    public Task<bool> UpdateByIdAsync(Customer customer)
    {
        var customerIndex = _customers.FindIndex(c => c.Id == customer.Id);
        if (customerIndex == -1) return Task.FromResult(false);
        _customers[customerIndex] = customer;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _customers.RemoveAll(c => c.Id == id);
        var customerRemoved = removedCount > 0;
        return Task.FromResult(customerRemoved);
    }
}