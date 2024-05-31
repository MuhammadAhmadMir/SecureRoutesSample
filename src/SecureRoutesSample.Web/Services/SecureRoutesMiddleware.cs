public class SecureRoutesMiddleware
{
    private readonly RequestDelegate _next;

    public SecureRoutesMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.User.Identity.IsAuthenticated)
        {
            if (!context.Request.Path.Equals("/Account/Login", StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 302;
                context.Response.Headers.Location = "/Account/Login";
                return;
            }
        }

        await _next(context);
    }
}
