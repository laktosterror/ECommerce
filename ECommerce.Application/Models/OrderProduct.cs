namespace ECommerce.Application.Models;

public class OrderProduct
{
    public required Guid OrderId { get; init; }
    public required Guid ProductId { get; init; }

    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}