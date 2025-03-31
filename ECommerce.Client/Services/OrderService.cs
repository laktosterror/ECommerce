using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public class OrderService : IOrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<OrdersResponse> GetOrdersAsync()
    {
        return await _httpClient.GetFromJsonAsync<OrdersResponse>("api/orders");
    }

    public async Task<OrderResponse> GetOrderAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<OrderResponse>($"api/orders/{id}");
    }

    public async Task CreateOrderAsync(CreateOrderRequest request)
    {
        await _httpClient.PostAsJsonAsync("api/orders", request);
    }

    public async Task UpdateOrderAsync(Guid id, UpdateOrderRequest request)
    {
        await _httpClient.PutAsJsonAsync($"api/orders/{id}", request);
    }

    public async Task DeleteOrderAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/orders/{id}");
    }
}