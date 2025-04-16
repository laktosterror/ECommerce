namespace ECommerce.Application.Models;

public class Customer
{
    public required Guid Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}