using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository;

public class VendorRepository : IVendorRepository
{
  private readonly AccountPayableDbContext _ctx;
  private readonly ILogger<VendorRepository> _logger;

  public VendorRepository(AccountPayableDbContext dbContext, ILogger<VendorRepository> logger)
  {
    _ctx = dbContext;
    _logger = logger;
  }

  /// <summary>
  /// Retrieves all asynchronous.
  /// </summary>
  /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
  /// <returns></returns>
  public async Task<IEnumerable<IVendor>> GetAllAsync()
  {
    // for performance, get from cache
    try
    {
      return await _ctx.Vendors.ToListAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot get all vendors.", ex);
      throw;
    }
  }

  /// <summary>
  /// Retrieves all asynchronous.
  /// </summary>
  /// <param name="active">if set to <c>true</c> [active].</param>
  /// <returns></returns>
  public async Task<IVendor> GetByIdAsync(int id)
  {
    // for performance, get from cache
    try
    {
      return await _ctx.Vendors.FirstOrDefaultAsync(x => x.Id == id);
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot get vendor with id={id}.", ex);
      throw;
    }
  }

}
