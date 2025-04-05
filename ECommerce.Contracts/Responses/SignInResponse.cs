namespace ECommerce.Contracts.Responses;

public class SignInResponse
{
    public string Token { get; set; }
    public string UserId { get; set; }
    public string UserName { get; set; }
}