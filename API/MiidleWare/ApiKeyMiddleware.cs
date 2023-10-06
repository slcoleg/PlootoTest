using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace AccountPayableAPI.MiidleWare;

/// <summary>
/// Security using API key
/// </summary>
public class ApiKeyMiddleware
{
  private readonly IConfiguration Configuration;
  private readonly RequestDelegate _next;
  const string API_KEY = "X-ApiKey";
  /// <summary>
  /// Initializes a new instance of the <see cref="ApiKeyMiddleware"/> class.
  /// </summary>
  /// <param name="next">The next.</param>
  /// <param name="configuration">The configuration.</param>
  public ApiKeyMiddleware(RequestDelegate next,   IConfiguration configuration)
  {
    _next = next;
    Configuration = configuration;
  }

  /// <summary>
  /// Invokes the specified HTTP context.
  /// </summary>
  /// <param name="httpContext">The HTTP context.</param>
  public async Task Invoke(HttpContext httpContext)
  {
    if (httpContext.Request.Path.StartsWithSegments("/API", StringComparison.OrdinalIgnoreCase))
    {
      bool success = httpContext.Request.Headers.TryGetValue(API_KEY, out var apiKeyFromHttpHeader);
      if (!success)
      {
        httpContext.Response.StatusCode = 401;
        await httpContext.Response.WriteAsync("The Api Key for accessing this endpoint is not available");
        return;
      }
      string api_key_From_Configuration = Configuration[API_KEY];
      if (!api_key_From_Configuration.Equals(apiKeyFromHttpHeader))
      {
        httpContext.Response.StatusCode = 401;
        await httpContext.Response.WriteAsync("The authentication key is incorrect : Unauthorized access");
        return;
      }
    }
    await _next(httpContext);
  }
}