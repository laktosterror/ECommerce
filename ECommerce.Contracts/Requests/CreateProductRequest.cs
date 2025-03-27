namespace ECommerce.Contracts.Requests;

public class CreateProductRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required string Category { get; set; }
    public required string Status { get; set; }
}