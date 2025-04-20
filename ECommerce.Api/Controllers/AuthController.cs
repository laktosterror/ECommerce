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

    [HttpPost(ApiEndpoints.Auth.Register)]
    public async Task<IActionResult> SignUp([FromBody] CreateUserRequest request)
    {
        var user = request.MapToUser();
        await _userRepository.CreateAsync(user);
        return Ok();
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
    public async Task<IActionResult> GetMyOrders()
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        if (string.IsNullOrEmpty(email))
        {
            return NotFound();
        }

        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
        {
            return NotFound();
        }
        var orders = await _orderRepository.GetAllByCustomerId(user.Customer.Id);
        return Ok(orders.MapToResponse());
    }

    [Authorize]
    [HttpPut("updatemyuser")]
    public async Task<IActionResult> UpdateMyUser([FromBody] UpdateUserRequest updateUserRequest)
    {
        var email = User.FindFirst(ClaimTypes.Email)?.Value;
        var currentUserState = await _userRepository.GetByEmailAsync(email);
        

        currentUserState.Email = updateUserRequest.Email;
        currentUserState.PasswordHash = BCrypt.Net.BCrypt.HashPassword(updateUserRequest.Password);
        currentUserState.Customer.Email = updateUserRequest.Email;
        currentUserState.Customer.FirstName = updateUserRequest.FirstName;
        currentUserState.Customer.LastName = updateUserRequest.LastName;
        currentUserState.Customer.PhoneNumber = updateUserRequest.PhoneNumber;
        currentUserState.Customer.Address = updateUserRequest.Address;

        await _userRepository.UpdateByIdAsync(currentUserState.Id, currentUserState);

        return Ok(currentUserState.MapToResponse());
    }

    [Authorize]
    [HttpPost("createmyorder")]
    public async Task<IActionResult> CreateMyOrder([FromBody] CreateOrderRequest createOrderRequest)
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

        createOrderRequest.CustomerId = user.Customer.Id;
        createOrderRequest.Status = "Waiting";
        createOrderRequest.OrderDate = DateTime.Now;
        
        var result = await _orderRepository.CreateAsync(createOrderRequest.MapToOrder());
        return Ok();
    }
}