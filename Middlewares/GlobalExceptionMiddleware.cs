using System.Diagnostics;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    { _next = next; _logger = logger; }

    public async Task InvokeAsync(HttpContext context)
    {
        try { await _next(context); }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            await HandleAsync(context, ex);
        }
    }

    private Task HandleAsync(HttpContext context, Exception ex)
    {
        int status = ex is BizException be ? be.StatusCode : 500;
        var payload = new { code = ex is BizException be2 ? be2.ErrorCode : "INTERNAL_ERROR", message = ex.Message, traceId = Activity.Current?.Id ?? Guid.NewGuid().ToString() };
        context.Response.StatusCode = status;
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsJsonAsync(payload);
    }
}
