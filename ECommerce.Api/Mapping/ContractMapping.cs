using System.Security.Cryptography;
using System.Text;
using ECommerce.Application.Models;
using ECommerce.Contracts.Requests;
using ECommerce.Contracts.Responses;

namespace ECommerce.Api.Mapping;

public static class ContractMapping
{
    public static Product MapToProduct(this CreateProductRequest request)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Category = request.Category,
            Status = request.Status
        };
    }

    public static ProductResponse MapToResponse(this Product product)
    {
        return new ProductResponse
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category,
            Status = product.Status
        };
    }

    public static ProductsResponse MapToResponse(this IEnumerable<Product> products)
    {
        return new ProductsResponse
        {
            Items = products.Select(MapToResponse)
        };
    }

    public static Product MapToProduct(this UpdateProductRequest request, Guid id)
    {
        return new Product
        {
            Id = id,
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Category = request.Category,
            Status = request.Status
        };
    }

    public static Customer MapToCustomer(this CreateCustomerRequest request)
    {
        return new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address
        };
    }

    public static CustomerResponse MapToResponse(this Customer customer)
    {
        return new CustomerResponse
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Address = customer.Address
        };
    }

    public static CustomersResponse MapToResponse(this IEnumerable<Customer> customers)
    {
        return new CustomersResponse
        {
            Items = customers.Select(MapToResponse)
        };
    }

    public static Customer MapToCustomer(this UpdateCustomerRequest request, Guid id)
    {
        return new Customer
        {
            Id = id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Address = request.Address
        };
    }


    public static Order MapToOrder(this CreateOrderRequest request)
    {
        var id = Guid.NewGuid();
        var orderProducts = request.ProductIds.Select(productId => new OrderProduct
        {
            OrderId = id,
            ProductId = productId
        }).ToList();
        
        return new Order
        {
            Id = id,
            CustomerId = request.CustomerId,
            OrderProducts = orderProducts,
            OrderDate = request.OrderDate,
            Status = request.Status
        };
    }

    public static OrderResponse MapToResponse(this Order order)
    {
        return new OrderResponse
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            CustomerFullName = $"{order.Customer.FirstName} {order.Customer.LastName}",
            Products = order.OrderProducts.Select(op => op.Product.MapToResponse()).ToList(),
            OrderDate = order.OrderDate,
            Status = order.Status
        };
    }

    public static OrdersResponse MapToResponse(this IEnumerable<Order> orders)
    {
        return new OrdersResponse
        {
            Items = orders.Select(MapToResponse)
        };
    }

    public static Order MapToOrder(this UpdateOrderRequest request, Guid id)
    {
        var orderProducts = request.ProductIds.Select(productId => new OrderProduct
        {
            OrderId = id,
            ProductId = productId
        }).ToList();

        return new Order
        {
            Id = id,
            CustomerId = request.CustomerId,
            OrderProducts = orderProducts,
            OrderDate = request.OrderDate,
            Status = request.Status
        };
    }
    
    public static User MapToUser(this CreateUserRequest request)
    {
        return new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = HashPassword(request.Password),
            Customer = new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            }
        };
    }
    
    public static UserResponse MapToResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.Customer.FirstName,
            LastName = user.Customer.LastName,
            PhoneNumber = user.Customer.PhoneNumber,
            Address = user.Customer.Address
        };
    }
    
    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static User MapToUser(this UpdateUserRequest request, Guid id)
    {
        return new User
        {
            Id = id,
            Email = request.Email,
            PasswordHash = request.Password != null ? HashPassword(request.Password) : null,
            Customer = new Customer
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address
            }
        };
    }
    
    public static UsersResponse MapToResponse(this IEnumerable<User> users)
    {
        return new UsersResponse()
        {
            Items = users.Select(MapToResponse)
        };
    }
}