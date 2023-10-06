
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Model;

namespace DataAccess;

public class AccountPayableDbContext : DbContext
{
  public DbSet<Vendor> Vendors { get; set; }
  public DbSet<Invoice> Invoices { get; set; }
  public DbSet<Payment> Payments { get; set; }

  private readonly IConfiguration _Config;

  public AccountPayableDbContext(IConfiguration config)
  {
    _Config = config;
  }
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(_Config.GetConnectionString("AccountPayableDatabase"));

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Vendor>().ToTable("Vendor");
    modelBuilder.Entity<Invoice>().ToTable("Invoice");
    modelBuilder.Entity<Payment>().ToTable("Payment");
  }
}