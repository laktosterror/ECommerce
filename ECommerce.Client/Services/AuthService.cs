using System.Net;
using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SignInResponse> SignInAsync(SignInRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/signin", request);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<SignInResponse>();
    }
}