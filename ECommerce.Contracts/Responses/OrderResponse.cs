namespace ECommerce.Contracts.Responses;

public class OrderResponse
{
    public required Guid Id { get; init; }
    public required Guid CustomerId { get; init; }
    public required IEnumerable<Guid> ProductIds { get; init; }
    public required DateTime OrderDate { get; init; }
    public required string Status { get; init; }
}