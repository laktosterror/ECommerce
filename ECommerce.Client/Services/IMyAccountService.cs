using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public interface IMyAccountService
{
    Task<CustomerResponse> GetMyInfo(string jwt);
    Task<OrdersResponse> GetMyOrdersAsync(string jwt);
}