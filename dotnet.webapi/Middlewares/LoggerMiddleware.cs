namespace dotnet.Middlewares
{
  public static class LoggerMiddlewareExtension
  {
    public static void UseLogger(this IApplicationBuilder app)
    {
      app.UseMiddleware<LoggerMiddleware>();
    }
  }

  public class LoggerMiddleware(
      RequestDelegate next,
      ILogger<LoggerMiddleware> logger)
  {
    private readonly RequestDelegate _next = next;
    private readonly ILogger<LoggerMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext ctx)
    {
      _logger.LogInformation($"Logger Middleware start ...... {ctx.Request.Path}");
      await _next(ctx);
      _logger.LogInformation("Logger Middleware end ......");
    }

  }
}
