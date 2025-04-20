using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Client.Services;

public interface IAuthService
{
    Task<SignInResponse> SignInAsync(SignInRequest request);
    Task<bool> SignUpAsync(CreateUserRequest request);
}