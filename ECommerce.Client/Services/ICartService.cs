using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public interface ICartService
{
    Task AddToCartAsync(ProductResponse productResponse);
    Task<IEnumerable<ProductResponse>> GetCartAsync();
    Task ClearCartAsync();
}
