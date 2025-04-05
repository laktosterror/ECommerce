namespace ECommerce.Contracts.Requests;

public class UpdateUserRequest
{
    public required string Email { get; init; }
    public string? Password { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Address { get; init; }
}