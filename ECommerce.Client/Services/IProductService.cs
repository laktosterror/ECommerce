using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public interface IProductService
{
    Task<ProductsResponse> GetProductsAsync();
    Task<ProductResponse> GetProductAsync(Guid id);
    Task CreateProductAsync(CreateProductRequest request);
    Task UpdateProductAsync(Guid id, UpdateProductRequest request);
    Task DeleteProductAsync(Guid id);
}