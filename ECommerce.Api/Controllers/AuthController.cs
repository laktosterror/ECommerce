using System.Security.Claims;
using ECommerce.Api;
using ECommerce.Application.Repositories;
using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using ECommerce.Api.Mapping;
using Microsoft.AspNetCore.Authorization;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IJwtService _jwtService;

    public AuthController(IUserRepository userRepository, IOrderRepository orderRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _orderRepository = orderRepository;
        _jwtService = jwtService;
    }

    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    /// <param name="request">The sign-in request.</param>
    /// <returns>The sign-in response containing the JWT token.</returns>
    [HttpPost(ApiEndpoints.Auth.SignIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Email and password are required.");
        }

        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return Unauthorized();
        }

        var token = _jwtService.GenerateToken(user.Id, user.Email);
        var response = new SignInResponse
        {
            Token = token,
            UserId = user.Id.ToString(),
            UserName = $"{user.Customer.FirstName} {user.Customer.LastName}"
        };

        return Ok(response);
    }

    [Authorize]
    [HttpGet("myaccount")]
    public async Task<IActionResult> GetMyAccount()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email))
        {
            return Unauthorized();
        }

        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.MapToResponse());
    }

    [Authorize]
    [HttpGet("myorders")]
    public async Task<IActionResult> GetMyOrders([FromRoute] Guid id)
    {
        var orders = await _orderRepository.GetAllByCustomerId(id);
        return Ok(orders.MapToResponse());
    }
}