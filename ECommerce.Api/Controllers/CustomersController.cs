using ECommerce.Api.Mapping;
using ECommerce.Application.Repositories;
using ECommerce.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="request">The create customer request.</param>
    /// <returns>The created customer response.</returns>
    [HttpPost(ApiEndpoints.Customers.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        if (request is null)
        {
            return BadRequest("Request body is required.");
        }
        
        var customer = request.MapToCustomer();
        await _customerRepository.CreateAsync(customer);
        return Created($"{ApiEndpoints.Customers.Create}/{customer.Id}", customer);
    }

    /// <summary>
    /// Gets a customer by ID.
    /// </summary>
    /// <param name="id">The customer ID.</param>
    /// <returns>The customer response.</returns>
    [HttpGet(ApiEndpoints.Customers.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null) return NotFound();
        return Ok(customer.MapToResponse());
    }

    /// <summary>
    /// Gets all customers.
    /// </summary>
    /// <returns>The list of customers.</returns>
    [HttpGet(ApiEndpoints.Customers.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerRepository.GetAllAsync();
        return Ok(customers.MapToResponse());
    }

    /// <summary>
    /// Updates a customer by ID.
    /// </summary>
    /// <param name="id">The customer ID.</param>
    /// <param name="request">The update customer request.</param>
    /// <returns>The updated customer response.</returns>
    [HttpPut(ApiEndpoints.Customers.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCustomerRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request body is required.");
        }
        
        var customer = request.MapToCustomer(id);
        var updated = await _customerRepository.UpdateByIdAsync(customer);
        if (!updated) return NotFound();

        var response = customer.MapToResponse();
        return Ok(response);
    }

    /// <summary>
    /// Deletes a customer by ID.
    /// </summary>
    /// <param name="id">The customer ID.</param>
    /// <returns>A success message.</returns>
    [HttpDelete(ApiEndpoints.Customers.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _customerRepository.DeleteByIdAsync(id);
        if (!deleted) return NotFound();

        return Ok();
    }
}