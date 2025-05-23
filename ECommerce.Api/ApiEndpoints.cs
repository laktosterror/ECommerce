namespace ECommerce.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Products
    {
        public const string Base = $"{ApiBase}/products";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class Customers
    {
        public const string Base = $"{ApiBase}/customers";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class Orders
    {
        public const string Base = $"{ApiBase}/orders";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class Users
    {
        public const string Base = $"{ApiBase}/users";
    
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class Auth
    {
        public const string SignIn = $"{ApiBase}/signin";
        public const string Register = $"{ApiBase}/register";
    }
}