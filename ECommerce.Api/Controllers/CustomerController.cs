using ECommerce.Api.Mapping;
using ECommerce.Application.Models;
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

    [HttpPost(ApiEndpoints.Customers.Create)]
    public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
    {
        var customer = request.MapToCustomer();
        await _customerRepository.CreateAsync(customer);
        return Created($"{ApiEndpoints.Customers.Create}/{customer.Id}", customer);
    }

    [HttpGet(ApiEndpoints.Customers.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var customer = await _customerRepository.GetByIdAsync(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Customers.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerRepository.GetAllAsync();
        return Ok(customers.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Customers.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCustomerRequest request)
    {
        var customer = request.MapToCustomer(id);
        var updated = await _customerRepository.UpdateByIdAsync(customer);
        if (!updated)
        {
            return NotFound();
        }

        var response = customer.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Customers.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _customerRepository.DeleteByIdAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}