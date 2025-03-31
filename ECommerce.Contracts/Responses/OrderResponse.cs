namespace ECommerce.Contracts.Responses;

public class OrderResponse
{
    public required Guid Id { get; init; }
    public required Guid CustomerId { get; init; }
    public required String CustomerFullName { get; init; }
    public required List<ProductResponse> Products { get; init; }
    public required DateTime OrderDate { get; init; }
    public required string Status { get; init; }
}