using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public interface IMyAccountService
{
    Task<CustomerResponse> GetMyInfo(string jwt);
    Task<OrdersResponse> GetMyOrdersAsync(string jwt);
    Task<UserResponse> UpdateMyUser(string jwt, UpdateUserRequest updateUserRequest);
    Task<bool> MakeOrder(string jwt, CreateOrderRequest createOrderRequest);
}