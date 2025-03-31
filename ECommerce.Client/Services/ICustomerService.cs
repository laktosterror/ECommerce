using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;
using ECommerce.Api.Mapping;

namespace ECommerce.Client.Services
{
    public interface ICustomerService
    {
        Task<CustomersResponse> GetCustomersAsync();
        Task<CustomerResponse> GetCustomerAsync(Guid id);
        Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);
        Task<CustomerResponse> UpdateCustomerAsync(Guid id, UpdateCustomerRequest request);
        Task DeleteCustomerAsync(Guid id);
    }
}