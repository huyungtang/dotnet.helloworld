namespace dotnet.Middlewares
{
  public static class ExceptionMiddlewareExtension
  {
    public static void UseException(this IApplicationBuilder app)
    {
      app.UseMiddleware<ExceptionMiddleware>();
    }
  }

  public class ExceptionMiddleware(
      RequestDelegate next,
      ILogger<ExceptionMiddleware> logger)
  {
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext ctx)
    {
      _logger.LogInformation("Exception Middleware start ......");
      try
      {
        await _next(ctx);
      }
      catch (Exception ex)
      {
        _ = ex;
      }
      _logger.LogInformation("Exception Middleware end ......");
    }

  }
}