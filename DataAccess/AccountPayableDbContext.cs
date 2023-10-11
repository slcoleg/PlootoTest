
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;

namespace DataAccess;

public class AccountPayableDbContext : DbContext
{
  public DbSet<Vendor> Vendors { get; set; }
  public DbSet<Invoice> Invoices { get; set; }
  public DbSet<Payment> Payments { get; set; }

  private readonly IConfiguration _Config;
  private readonly ILogger<AccountPayableDbContext> _Logger;

  public AccountPayableDbContext(IConfiguration config, ILogger<AccountPayableDbContext> logger)
  {
    _Config = config;
    _Logger = logger;
  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(_Config.GetConnectionString("AccountPayableDatabase"));

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Vendor>().ToTable("Vendor");
    modelBuilder.Entity<Invoice>().ToTable("Invoice");
    modelBuilder.Entity<Payment>().ToTable("Payment");

    _Logger.LogInformation($"Seeding {nameof(Vendor)} table.");
    modelBuilder.Entity<Vendor>().HasData
      (
        new Vendor { Id=1, Name = "MSDN", Address = "123 Street West, Dallas", Description = "Microsoft Subscriptions" },
        new Vendor { Id=2, Name = "Docker", Address = "4 Main Street, NY", Description = "Repo" },
        new Vendor { Id=3, Name = "EFCore", Address = "5 Quieen Street, Boston", Description = "Books" },
        new Vendor { Id=4, Name = "Oracle", Address = "6 CoonWelth Avenue, Berlin", Description = "Education" }
      );
    
    _Logger.LogInformation($"Seeding {nameof(Invoice)} table.");
    modelBuilder.Entity<Invoice>().HasData
      (
        new Invoice { Id = 1, VendorId = 1, Amount = 100, State = 0, Description = "MSDN Subscription", IssuedDate = DateTime.Now.AddDays(-1), DueDate = DateTime.Now.AddDays(5) },
        new Invoice { Id = 2, VendorId = 2, Amount = 123, State = 0, Description = "Private hub", IssuedDate = DateTime.Now.AddDays(-12), DueDate = DateTime.Now.AddDays(12) },
        new Invoice { Id = 3, VendorId = 1, Amount = 345, State = 0, Description = "Office", IssuedDate = DateTime.Now.AddDays(-21), DueDate = DateTime.Now.AddDays(3) },
        new Invoice { Id = 4, VendorId = 1, Amount = 22.22m, State = 0, Description = "Visio", IssuedDate = DateTime.Now.AddDays(-31), DueDate = DateTime.Now.AddDays(1) },
        new Invoice { Id = 5, VendorId = 3, Amount = 12.11m, State = 0, Description = "Training", IssuedDate = DateTime.Now.AddDays(-3), DueDate = DateTime.Now.AddDays(7) }
      );
  }
}