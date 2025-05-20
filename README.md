# API Solution

This solution is a C# Web API built with .NET 8, designed to provide a robust and extensible backend for your application. It follows modern best practices, including dependency injection, middleware for exception handling, and integrated Swagger documentation for easy API exploration.

## Features

- **.NET 8** and **C# 12** support
- Modular dependency injection setup
- Centralized exception handling via custom middleware
- Secure HTTPS redirection
- Authorization middleware
- Automatic API documentation with Swagger (enabled in development)
- Organized validation logic for category-related operations

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- An IDE such as Visual Studio 2022

### Running the API

1. Clone the repository.
2. Navigate to the solution directory.
3. Build the solution:
	dotnet build
4. Run the API project:
	dotnet run --project API

5. The API will be available at `https://localhost:5001` (or the configured port).

### API Documentation

- When running in the Development environment, Swagger UI is available at:  
  `https://localhost:5001/swagger`

## Project Structure

- `API/Program.cs` – Application entry point and middleware configuration
- `API/Middlewares/ExceptionHandlingMiddleware.cs` – Global exception handling
- `Application/Common/Validators/Categories/` – Validators for category commands

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.


   