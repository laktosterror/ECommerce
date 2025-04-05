namespace ECommerce.Contracts.Requests;

public class CreateUserRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Address { get; init; }
}