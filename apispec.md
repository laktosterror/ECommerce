
### AuthController

#### Endpoints

1. **Sign In**
    - **Method**: POST
    - **URL**: `/api/signin`
    - **Description**: Authenticates a user and returns a JWT token.
    - **Request Body**:
      ```json
      {
        "Email": "string",
        "Password": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Token": "string",
        "UserId": "string",
        "UserName": "string"
      }
      ```

2. **Get My Account**
    - **Method**: GET
    - **URL**: `/myaccount`
    - **Description**: Retrieves the account information of the authenticated user.
    - **Headers**:
        - `Authorization`: `Bearer <token>`
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

3. **Get My Orders**
    - **Method**: GET
    - **URL**: `/myorders`
    - **Description**: Retrieves the orders of the authenticated user.
    - **Headers**:
        - `Authorization`: `Bearer <token>`
    - **Response**:
      ```json
      [
        {
          "Id": "guid",
          "OrderDate": "datetime",
          "Status": "string",
          "Products": [
            {
              "Id": "guid",
              "Name": "string",
              "Description": "string",
              "Category": "string",
              "Price": "decimal",
              "Status": "string"
            }
          ]
        }
      ]
      ```

4. **Update My User**
    - **Method**: PUT
    - **URL**: `/updatemyuser`
    - **Description**: Updates the information of the authenticated user.
    - **Headers**:
        - `Authorization`: `Bearer <token>`
    - **Request Body**:
      ```json
      {
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string",
        "Password": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

5. **Create My Order**
    - **Method**: POST
    - **URL**: `/createmyorder`
    - **Description**: Creates an order for the authenticated user.
    - **Headers**:
        - `Authorization`: `Bearer <token>`
    - **Request Body**:
      ```json
      {
        "CustomerId": "guid",
        "Status": "string",
        "OrderDate": "datetime",
        "ProductIds": ["guid"]
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "OrderDate": "datetime",
        "Status": "string",
        "Products": [
          {
            "Id": "guid",
            "Name": "string",
            "Description": "string",
            "Category": "string",
            "Price": "decimal",
            "Status": "string"
          }
        ]
      }
      ```

### CustomersController

#### Endpoints

1. **Create Customer**
    - **Method**: POST
    - **URL**: `/api/customers`
    - **Description**: Creates a new customer.
    - **Request Body**:
      ```json
      {
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

2. **Get Customer**
    - **Method**: GET
    - **URL**: `/api/customers/{id:guid}`
    - **Description**: Retrieves a customer by ID.
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

3. **Get All Customers**
    - **Method**: GET
    - **URL**: `/api/customers`
    - **Description**: Retrieves all customers.
    - **Response**:
      ```json
      [
        {
          "Id": "guid",
          "Email": "string",
          "FirstName": "string",
          "LastName": "string",
          "PhoneNumber": "string",
          "Address": "string"
        }
      ]
      ```

4. **Update Customer**
    - **Method**: PUT
    - **URL**: `/api/customers/{id:guid}`
    - **Description**: Updates a customer by ID.
    - **Request Body**:
      ```json
      {
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

5. **Delete Customer**
    - **Method**: DELETE
    - **URL**: `/api/customers/{id:guid}`
    - **Description**: Deletes a customer by ID.
    - **Response**:
      ```json
      {
        "message": "string"
      }
      ```

### OrdersController

#### Endpoints

1. **Create Order**
    - **Method**: POST
    - **URL**: `/api/orders`
    - **Description**: Creates a new order.
    - **Request Body**:
      ```json
      {
        "CustomerId": "guid",
        "Status": "string",
        "OrderDate": "datetime",
        "ProductIds": ["guid"]
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "OrderDate": "datetime",
        "Status": "string",
        "Products": [
          {
            "Id": "guid",
            "Name": "string",
            "Description": "string",
            "Category": "string",
            "Price": "decimal",
            "Status": "string"
          }
        ]
      }
      ```

2. **Get Order**
    - **Method**: GET
    - **URL**: `/api/orders/{id:guid}`
    - **Description**: Retrieves an order by ID.
    - **Response**:
      ```json
      {
        "Id": "guid",
        "OrderDate": "datetime",
        "Status": "string",
        "Products": [
          {
            "Id": "guid",
            "Name": "string",
            "Description": "string",
            "Category": "string",
            "Price": "decimal",
            "Status": "string"
          }
        ]
      }
      ```

3. **Get All Orders**
    - **Method**: GET
    - **URL**: `/api/orders`
    - **Description**: Retrieves all orders.
    - **Response**:
      ```json
      [
        {
          "Id": "guid",
          "OrderDate": "datetime",
          "Status": "string",
          "Products": [
            {
              "Id": "guid",
              "Name": "string",
              "Description": "string",
              "Category": "string",
              "Price": "decimal",
              "Status": "string"
            }
          ]
        }
      ]
      ```

4. **Update Order**
    - **Method**: PUT
    - **URL**: `/api/orders/{id:guid}`
    - **Description**: Updates an order by ID.
    - **Request Body**:
      ```json
      {
        "CustomerId": "guid",
        "Status": "string",
        "OrderDate": "datetime",
        "ProductIds": ["guid"]
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "OrderDate": "datetime",
        "Status": "string",
        "Products": [
          {
            "Id": "guid",
            "Name": "string",
            "Description": "string",
            "Category": "string",
            "Price": "decimal",
            "Status": "string"
          }
        ]
      }
      ```

5. **Delete Order**
    - **Method**: DELETE
    - **URL**: `/api/orders/{id:guid}`
    - **Description**: Deletes an order by ID.
    - **Response**:
      ```json
      {
        "message": "string"
      }
      ```

### ProductsController

#### Endpoints

1. **Create Product**
    - **Method**: POST
    - **URL**: `/api/products`
    - **Description**: Creates a new product.
    - **Request Body**:
      ```json
      {
        "Name": "string",
        "Description": "string",
        "Category": "string",
        "Price": "decimal",
        "Status": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Name": "string",
        "Description": "string",
        "Category": "string",
        "Price": "decimal",
        "Status": "string"
      }
      ```

2. **Get Product**
    - **Method**: GET
    - **URL**: `/api/products/{id:guid}`
    - **Description**: Retrieves a product by ID.
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Name": "string",
        "Description": "string",
        "Category": "string",
        "Price": "decimal",
        "Status": "string"
      }
      ```

3. **Get All Products**
    - **Method**: GET
    - **URL**: `/api/products`
    - **Description**: Retrieves all products.
    - **Response**:
      ```json
      [
        {
          "Id": "guid",
          "Name": "string",
          "Description": "string",
          "Category": "string",
          "Price": "decimal",
          "Status": "string"
        }
      ]
      ```

4. **Update Product**
    - **Method**: PUT
    - **URL**: `/api/products/{id:guid}`
    - **Description**: Updates a product by ID.
    - **Request Body**:
      ```json
      {
        "Name": "string",
        "Description": "string",
        "Category": "string",
        "Price": "decimal",
        "Status": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Name": "string",
        "Description": "string",
        "Category": "string",
        "Price": "decimal",
        "Status": "string"
      }
      ```

5. **Delete Product**
    - **Method**: DELETE
    - **URL**: `/api/products/{id:guid}`
    - **Description**: Deletes a product by ID.
    - **Response**:
      ```json
      {
        "message": "string"
      }
      ```

### UsersController

#### Endpoints

1. **Create User**
    - **Method**: POST
    - **URL**: `/api/users`
    - **Description**: Creates a new user.
    - **Request Body**:
      ```json
      {
        "Email": "string",
        "Password": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

2. **Get User**
    - **Method**: GET
    - **URL**: `/api/users/{id:guid}`
    - **Description**: Retrieves a user by ID.
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

3. **Get All Users**
    - **Method**: GET
    - **URL**: `/api/users`
    - **Description**: Retrieves all users.
    - **Response**:
      ```json
      [
        {
          "Id": "guid",
          "Email": "string",
          "FirstName": "string",
          "LastName": "string",
          "PhoneNumber": "string",
          "Address": "string"
        }
      ]
      ```

4. **Update User**
    - **Method**: PUT
    - **URL**: `/api/users/{id:guid}`
    - **Description**: Updates a user by ID.
    - **Request Body**:
      ```json
      {
        "Email": "string",
        "Password": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```
    - **Response**:
      ```json
      {
        "Id": "guid",
        "Email": "string",
        "FirstName": "string",
        "LastName": "string",
        "PhoneNumber": "string",
        "Address": "string"
      }
      ```

5. **Delete User**
    - **Method**: DELETE
    - **URL**: `/api/users/{id:guid}`
    - **Description**: Deletes a user by ID.
    - **Response**:
      ```json
      {
        "message": "string"
      }
      ```
      