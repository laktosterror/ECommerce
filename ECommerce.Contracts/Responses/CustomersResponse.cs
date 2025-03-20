namespace ECommerce.Contracts.Responses;

public class CustomersResponse
{
    public required IEnumerable<CustomerResponse> Items { get; init; }
}