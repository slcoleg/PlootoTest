using Interfaces;
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
  public async Task<IEnumerable<IPayment>> GetAllAsync()
  {
    // for performance, get from cache
    try
    {
      return await _ctx.Payments.ToListAsync();
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
  public async Task<IEnumerable<IPayment>> AddAsync(IPayment[] payments)
  {
    // for performance, get from cache
    try
    {
      if (payments == null)
      {
        return null;
      }
      var ids = payments.Select(x => x.InvoiceId).ToList();
      // Simple validation if invoice already paid (payment record exists) but not marked as paid
      var existingPayments = _ctx.Payments.Where(_ => ids.Contains(_.InvoiceId)).ToList();
      foreach (var payment in payments)
      {
        var existingPayment = existingPayments.FirstOrDefault(_ => _.InvoiceId == payment.InvoiceId && _.VendorId == payment.VendorId);
        if (existingPayment == null)
        {
          try
          {
            await _ctx.AddAsync(payment);
          }
          catch (Exception inEx)
          {
            _logger.LogWarning($"Cannot create payment for Invoice.", inEx);
          }
        }
        else
        {
          // Possible double payment
          _logger.LogWarning($"Cannot create payment for Invoice with id={payment.InvoiceId} for vendor {payment.VendorId}. Invoice already paid. Payment id={existingPayment.Id}");
        }
      }
      await _ctx.SaveChangesAsync();
      _logger.LogInformation($"Created payment for Invoices.");
      return payments;
    }
    catch (Exception ex)
    {
      _logger.LogError($"Cannot create payment for Invoices.", ex);
      throw;
    }
  }
}
