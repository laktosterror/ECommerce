using ECommerce.Api.Mapping;
using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public class CustomerService : ICustomerService
{
    private readonly HttpClient _httpClient;

    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CustomersResponse> GetCustomersAsync()
    {
        var response = await _httpClient.GetAsync("api/customers");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomersResponse>();
    }

    public async Task<CustomerResponse> GetCustomerAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/customers/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerResponse>();
    }

    public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/customers", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerResponse>();
    }

    public async Task<CustomerResponse> UpdateCustomerAsync(Guid id, UpdateCustomerRequest request)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customers/{id}", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerResponse>();
    }

    public async Task DeleteCustomerAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/customers/{id}");
        response.EnsureSuccessStatusCode();
    }
}