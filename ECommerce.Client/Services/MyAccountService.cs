using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public class MyAccountService : IMyAccountService
{
    private readonly HttpClient _httpClient;
    private readonly IAuthService _authService;
    
    public MyAccountService(HttpClient httpClient, IAuthService authService)
    {
        _httpClient = httpClient;
        _authService = authService;
    }

    public async Task<CustomerResponse> GetMyInfo(string jwt)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwt);
        var response = await _httpClient.GetAsync("myaccount");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<CustomerResponse>();
    }

    public async Task<OrdersResponse> GetMyOrdersAsync(string jwt)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", jwt);
        var response = await _httpClient.GetAsync("myorders");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<OrdersResponse>();
    }
}
