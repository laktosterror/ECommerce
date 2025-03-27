using System.Net.Http.Json;
using ECommerce.Contracts.Responses;
using ECommerce.Contracts.Requests;

namespace ECommerce.Client.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ProductsResponse> GetProductsAsync()
    {
        return await _httpClient.GetFromJsonAsync<ProductsResponse>("api/products");
    }

    public async Task<ProductResponse> GetProductAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<ProductResponse>($"api/products/{id}");
    }

    public async Task CreateProductAsync(CreateProductRequest request)
    {
        await _httpClient.PostAsJsonAsync("api/products", request);
    }

    public async Task UpdateProductAsync(Guid id, UpdateProductRequest request)
    {
        await _httpClient.PutAsJsonAsync($"api/products/{id}", request);
    }

    public async Task DeleteProductAsync(Guid id)
    {
        await _httpClient.DeleteAsync($"api/products/{id}");
    }
}
