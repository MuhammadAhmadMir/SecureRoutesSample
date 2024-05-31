# Secure Routing Middleware Example

This repository contains an example of how to implement secure routing middleware in an ASP.NET Core application using .NET 8. The middleware is designed to protect routes that require authentication, redirect unauthenticated users to the login page, and handle authorization errors.

## Features

- Implements middleware to protect routes that require authentication.
- Redirects unauthenticated users to the login page.
- Handles authorization errors and shows an "Access Denied" message.

## Prerequisites

- .NET 8 SDK
- Visual Studio or Visual Studio Code (optional)

## Getting Started

1. Clone this repository to your local machine

2. Open the solution in Visual Studio or Visual Studio Code.

3. Build and run the application.

4. Navigate to the secure routes that require authentication, to see the middleware in action.

## Usage

The `SecureRoutesMiddleware` class is responsible for protecting routes that require authentication. It checks if the user is authenticated and redirects unauthenticated users to the login page. The middleware is added to the pipeline in the `Program.cs`.

```csharp
app.UseMiddleware<SecureRoutesMiddleware>();
```

## Configuration

The authentication and authorization setup is done in the `AddAuthentication` method of `Startup.cs`. Ensure that the authentication scheme name used in the middleware (`CookieAuth`) matches the one used in `AddAuthentication`.

```csharp
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        config.LoginPath = "/Account/Login";
        config.AccessDeniedPath = "/Account/AccessDenied";
    });
```

## Contributing

Contributions are welcome! Feel free to fork this repository and submit pull requests with your improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
