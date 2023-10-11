using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace API;

/// <summary>
/// MigrationManager
/// </summary>
public static class MigrationManager
{
  /// <summary>
  /// Migrates the database.
  /// </summary>
  /// <param name="app">The application.</param>
  /// <returns></returns>
  public static WebApplication MigrateDatabase(this WebApplication app)
  {
    Console.WriteLine("----------- MIGRATION -----------");
    using var scope = app.Services.CreateScope();
    using var db = scope.ServiceProvider.GetService<AccountPayableDbContext>();
    try
    {
      db.Database.Migrate();
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Migration Error: {ex.Message}");
      throw;
    }
    return app;
  }
}
