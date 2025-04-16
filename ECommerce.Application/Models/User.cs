namespace ECommerce.Application.Models;

public class User
{
    public required Guid Id { get; init; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }
}