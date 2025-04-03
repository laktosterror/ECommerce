namespace ECommerce.Application.Models;

public class User
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
    public required string PasswordHash { get; init; }
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }
}