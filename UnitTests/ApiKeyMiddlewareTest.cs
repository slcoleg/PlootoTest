using AccountPayableAPI.MiidleWare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UnitTests;

public class ApiKeyMiddlewareTest
{
  public static IConfigurationRoot GetIConfigurationRoot()
  {
    return new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true)
        .AddUserSecrets("e3dfcccf-0cb3-423a-b302-e3e92e95c128")
        .AddEnvironmentVariables()
        .Build();
  }

  public async Task<IHost> InitHost()
  {
    var hostBuilder = new HostBuilder()
      .ConfigureWebHost(webHost =>
      {
        webHost.UseTestServer();
        webHost.ConfigureAppConfiguration((context, builder) => { builder.AddJsonFile("appsettings.json"); });
        webHost.Configure(app =>
                app.UseMiddleware<ApiKeyMiddleware>()
              );
      });

    return await hostBuilder.StartAsync();
  }

  [Fact]
  public async Task StatusMiddlewareReturnsNotAuthorized()
  {
    IHost host = await InitHost();
    HttpClient client = host.GetTestClient();

    // Act
    var response = await client.GetAsync("/");

    // Assert
    Assert.Throws<System.Net.Http.HttpRequestException>(() => response.EnsureSuccessStatusCode());
  }

  [Fact]
  public async Task StatusMiddlewareReturnsHealthy()
  {
    IHost host = await InitHost();

    HttpClient client = host.GetTestClient();

    var key = GetIConfigurationRoot()["X-ApiKey"];
    client.DefaultRequestHeaders.Add("X-ApiKey", key);
    // Act
    var response = await client.GetAsync("/");

    // Assert
    response.EnsureSuccessStatusCode();
    var content = await response.Content.ReadAsStringAsync();

    Assert.Equal("healthy", content, true);
  }
}