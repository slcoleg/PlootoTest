using Interfaces.Invoice;
using Interfaces.Payment;
using Interfaces.Vendor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository;

public class PaymentRepository : IPaymentRepository
{
  private readonly AccountPayableDbContext _ctx;
  private readonly ILogger<PaymentRepository> _logger;

  public PaymentRepository(AccountPayableDbContext dbContext, ILogger<PaymentRepository> logger)
  {
    _ctx = dbContext;
    _logger = logger;
  }

  /// <summary>
  /// Retrieves all asynchronous.
  /// </summary>
  /// <param name="state">if set [with state only].</param>
  /// <returns></returns>
  public async Task<IEnumerable<IPayment>> GetAllAsync(int? state)
  {
    // for performance, get from cache
    try
    {
      return state.HasValue ? await _ctx.Payments.Where(x => x.State != state.Value).ToListAsync() : await _ctx.Payments.ToListAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot get all payments.", ex);
      throw;
    }
  }

  /// <summary>
  /// Retrieves all asynchronous.
  /// </summary>
  /// <param name="active">if set to <c>true</c> [active].</param>
  /// <returns></returns>
  public async Task<IPayment> GetByIdAsync(int id)
  {
    // for performance, get from cache
    try
    {
      return await _ctx.Payments.FirstOrDefaultAsync(x => x.Id == id);
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot get payment with id={id}.", ex);
      throw;
    }
  }

  /// <summary>
  /// Adds the asynchronous.
  /// </summary>
  /// <param name="payment">The payment.</param>
  /// <returns></returns>
  public async Task<bool> AddAsync(IPayment payment)
  {
    // for performance, get from cache
    try
    {
      if (payment == null)
      {
        return false;
      }
      var existingPayment = await _ctx.Payments.FirstOrDefaultAsync(x => x.VendorId == payment.VendorId && x.InvoiceId == payment.InvoiceId);
      if (existingPayment == null)
      {
        await _ctx.AddAsync(payment);
        _ctx.SaveChanges();
        _logger.LogInformation($"Created payment for Invoice with id={payment.InvoiceId} for vendor {payment.VendorId}.");
        return true;
      }
      _logger.LogWarning($"Cannot create payment for Invoice with id={payment.InvoiceId} for vendor {payment.VendorId}. Invoice already paid. Payment id={existingPayment.Id}");
      return false;
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot create payment for Invoice withid={payment.InvoiceId} for vendor {payment.VendorId}.", ex);
      throw;
    }
  }
}
