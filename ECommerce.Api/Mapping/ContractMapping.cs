using ECommerce.Application.Models;
using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Api.Mapping;

public static class ContractMapping
{
    public static Product MapToProduct(this CreateProductRequest request)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Category = request.Category,
            Status = request.Status,
        };
    }

    public static ProductResponse MapToResponse(this Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            Status = product.Status,
        };
    }

    public static ProductsResponse MapToResponse(this IEnumerable<Product> products)
    {
        return new ProductsResponse()
        {
            Items = products.Select(MapToResponse)
        };
    }
    
    public static Product MapToProduct(this UpdateProductRequest request, Guid id)
    {
        return new Product
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Category = request.Category,
            Status = request.Status,
        };
    }
}