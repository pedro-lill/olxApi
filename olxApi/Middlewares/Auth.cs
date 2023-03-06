using olxApi.Data;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    private readonly OlxContext _context;
    public AuthMiddleware(RequestDelegate next, OlxContext context)
    {
        _next = next;
        _context = context;
    }
    public async Task InvokeAsync(HttpContext context)
    {

        var user = _context.Users.FirstOrDefault(user =>
            user.token == context.Request.Headers["token"]);

        if (user == null)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized");
            return;
        }
        await _next(context);
        

    }
}