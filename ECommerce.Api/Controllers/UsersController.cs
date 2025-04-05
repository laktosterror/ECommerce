using ECommerce.Api.Mapping;
using ECommerce.Application.Repositories;
using ECommerce.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost(ApiEndpoints.Users.Create)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var user = request.MapToUser();
        await _userRepository.CreateAsync(user);
        return Created($"{ApiEndpoints.Users.Create}/{user.Id}", user.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Users.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Users.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userRepository.GetAllAsync();
        return Ok(users.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Users.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequest request)
    {
        var user = request.MapToUser(id);
        var updated = await _userRepository.UpdateByIdAsync(user);
        if (!updated) return NotFound();

        var response = user.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Users.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _userRepository.DeleteByIdAsync(id);
        if (!deleted) return NotFound();

        return Ok();
    }
}