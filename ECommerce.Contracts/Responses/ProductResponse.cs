namespace ECommerce.Contracts.Responses;

public class ProductResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    public required string Category { get; init; }
    public required string Status { get; init; }
}