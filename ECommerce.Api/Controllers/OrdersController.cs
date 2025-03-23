using ECommerce.Api.Mapping;
using ECommerce.Application.Repositories;
using ECommerce.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;

    public OrdersController(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpPost(ApiEndpoints.Orders.Create)]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var order = request.MapToOrder();
        await _orderRepository.CreateAsync(order);

        var createdOrder = await _orderRepository.GetByIdAsync(order.Id);
        if (createdOrder == null) return NotFound();
        return Created($"{ApiEndpoints.Orders.Create}/{order.Id}", createdOrder.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Orders.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null) return NotFound();
        return Ok(order.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Orders.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderRepository.GetAllAsync();
        return Ok(orders.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Orders.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrderRequest request)
    {
        var order = request.MapToOrder(id);
        var updated = await _orderRepository.UpdateAsync(order);
        if (!updated) return NotFound();

        var response = order.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Orders.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _orderRepository.DeleteByIdAsync(id);
        if (!deleted) return NotFound();

        return Ok();
    }
}