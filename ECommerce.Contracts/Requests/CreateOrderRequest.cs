namespace ECommerce.Contracts.Requests;

public class CreateOrderRequest
{
    public required Guid CustomerId { get; set; }
    public required IEnumerable<Guid> ProductIds { get; set; }
    public required DateTime OrderDate { get; set; }
    public required string Status { get; set; }
}