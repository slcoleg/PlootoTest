using Interfaces.Invoice;
using Interfaces.Vendor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository;

public class InvoiceRepository : IInvoiceRepository
{
  private readonly AccountPayableDbContext _ctx;
  private readonly ILogger<InvoiceRepository> _logger;

  public InvoiceRepository(AccountPayableDbContext dbContext, ILogger<InvoiceRepository> logger)
  {
    _ctx = dbContext;
    _logger = logger;
  }

  /// <summary>
  /// Retrieves all asynchronous.
  /// </summary>
  /// <param name="activeOnly">if set to <c>true</c> [active only].</param>
  /// <returns></returns>
  public async Task<IEnumerable<IInvoice>> GetAllAsync(int? state)
  {
    // for performance, get from cache
    try
    {
      return state.HasValue ? await _ctx.Invoices.Where(x => x.State != state.Value).ToListAsync() : await _ctx.Invoices.ToListAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot get all invoices.", ex);
      throw;
    }
  }

  /// <summary>
  /// Retrieves all asynchronous.
  /// </summary>
  /// <param name="active">if set to <c>true</c> [active].</param>
  /// <returns></returns>
  public async Task<IInvoice> GetByIdAsync(int id)
  {
    // for performance, get from cache
    try
    {
      return await _ctx.Invoices.FirstOrDefaultAsync(x => x.Id == id);
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot get invoice with id={id}.", ex);
      throw;
    }
  }

  /// <summary>
  /// Updates the asynchronous.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <param name="state">The state.</param>
  /// <returns></returns>
  public async Task<bool> UpdateAsync(int id, int state)
  {
    // for performance, get from cache
    try
    {
      var invoice = await _ctx.Invoices.FirstOrDefaultAsync(x => x.Id == id);
      if (invoice != null)
      {
        var oldState = invoice.State;
        invoice.State = state;
        await _ctx.SaveChangesAsync();
        _logger.LogInformation($"Invoice with id={id} state updated from {oldState} to {state}.");
        return true;
      }
      _logger.LogWarning($"Cannot update state of Invoice with id={id} to {state}, because it's olready has the same state.");
      return false;
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot update invoice with id={id}.", ex);
      throw;
    }
  }
}
