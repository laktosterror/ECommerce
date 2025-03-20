namespace ECommerce.Contracts.Requests;

public class UpdateOrderRequest
{
    public required Guid CustomerId { get; init; }
    public required IEnumerable<Guid> ProductIds { get; init; }
    public required DateTime OrderDate { get; init; }
    public required string Status { get; init; }
}