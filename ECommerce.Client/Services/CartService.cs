using ECommerce.Contracts.Responses;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ECommerce.Client.Services;


public class CartService : ICartService
{
    private readonly ProtectedSessionStorage _protectedSessionStorage;

    private HttpClient _httpClient;

    public CartService(ProtectedSessionStorage protectedSessionStorage, HttpClient httpClient)
    {
        _protectedSessionStorage = protectedSessionStorage;
        _httpClient = httpClient;
    }

    public async Task AddToCartAsync(ProductResponse productResponse)
    {
        var cart = await GetCartAsync() ?? new List<ProductResponse>();

        cart = cart.Append(productResponse).ToList();
        await _protectedSessionStorage.SetAsync("cart", cart);
    }

    public async Task<IEnumerable<ProductResponse>> GetCartAsync()
    {
        var result = await _protectedSessionStorage.GetAsync<IEnumerable<ProductResponse>>("cart");
        return result.Success ? result.Value : null;
    }



    public async Task ClearCartAsync()
    {
        await _protectedSessionStorage.DeleteAsync("cart");
    }
}
