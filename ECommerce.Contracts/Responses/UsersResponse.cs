namespace ECommerce.Contracts.Responses;

public class UsersResponse
{
    public required IEnumerable<UserResponse> Items { get; init; }
}