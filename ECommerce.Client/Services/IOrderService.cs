using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public interface IOrderService
{
    Task<OrdersResponse> GetOrdersAsync();
    Task<OrderResponse> GetOrderAsync(Guid id);
    Task CreateOrderAsync(CreateOrderRequest request);
    Task UpdateOrderAsync(Guid id, UpdateOrderRequest request);
    Task DeleteOrderAsync(Guid id);
}