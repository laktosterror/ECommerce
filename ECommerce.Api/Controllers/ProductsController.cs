using ECommerce.Api.Mapping;
using ECommerce.Application.Models;
using ECommerce.Application.Repositories;
using ECommerce.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpPost(ApiEndpoints.Products.Create)]
    public async Task<IActionResult> Create([FromBody]CreateProductRequest request)
    {
        var product = request.MapToProduct();
        await _productRepository.CreateAsync(product);
        return Created($"{ApiEndpoints.Products.Create}/{product.Id}", product);
    }

    [HttpGet(ApiEndpoints.Products.Get)]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product.MapToResponse());
    }

    [HttpGet(ApiEndpoints.Products.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productRepository.GetAllAsync();

        return Ok(products.MapToResponse());
    }

    [HttpPut(ApiEndpoints.Products.Update)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
    {
        var product = request.MapToProduct(id);
        var updated = await _productRepository.UpdateByIdAsync(product);
        if (!updated)
        {
            return NotFound();
        }

        var response = product.MapToResponse();
        return Ok(response);
    }

    [HttpDelete(ApiEndpoints.Products.Delete)]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleted = await _productRepository.DeleteByIdAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}