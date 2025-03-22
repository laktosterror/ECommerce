namespace ECommerce.Application.Models;

public class Customer
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Address { get; init; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}