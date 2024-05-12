# E-Commerce API

## Overview
Welcome to the E-Commerce API! This project provides a robust backend for managing products, carts, orders, and user authorization in an e-commerce application. With a comprehensive set of endpoints, it facilitates browsing products, adding items to carts, placing orders, and viewing order history. Additionally, it offers CRUD operations for product management, including the ability to upload product images.

## Technologies Used
- **ASP.NET Core**: The framework for building the API, offering scalability, performance, and cross-platform compatibility.
- **C#**: The primary programming language for backend development, providing a strong, statically-typed environment.
- **Entity Framework Core**: For interacting with the database, enabling seamless data access and manipulation.
- **JWT (JSON Web Tokens)**: Used for user authentication and authorization, providing a secure way to transmit information between parties.
- **Swagger/OpenAPI**: For API documentation and testing, enhancing developer experience and facilitating client integration.
- **SQL Server/MySQL/PostgreSQL**: Depending on preference or requirements, one of these relational databases is used for storing product, user, and order information.
- **Image Processing Library (e.g., ImageSharp)**: Employed for handling product images, enabling upload, storage, and retrieval functionalities.
- **Git/GitHub**: Version control system and hosting platform for collaborative development, ensuring code integrity and manageability.

## Endpoints
The API offers the following endpoints:
- Authorization endpoints for user authentication and authorization.
- Endpoints for retrieving products with optional parameters for category and name filtration.
- Product details endpoint for retrieving information about a specific product.
- Add to cart, remove item from cart, and edit item quantity in cart endpoints for managing user carts.
- Place order endpoint for submitting orders with product IDs and quantities.
- View orders history endpoint for retrieving past orders with details such as ID, creation datetime, and total price.

## Setup Instructions
1. Clone the repository: `git clone <repository_url>`
2. Navigate to the project directory: `cd ecommerce-api`
3. Install dependencies: `dotnet restore`
4. Configure database connection in `appsettings.json`
5. Apply EF migrations: `dotnet ef database update`
6. Run the application: `dotnet run`

## API Documentation
After running the application, you can access the Swagger documentation by navigating to `https://localhost:<port>/swagger` in your browser. This provides detailed information about each endpoint, request parameters, and response schemas, allowing for easy testing and integration.

## Contributing
Contributions are welcome! Feel free to fork the repository, make changes, and submit pull requests. Please follow the existing code style and guidelines.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

