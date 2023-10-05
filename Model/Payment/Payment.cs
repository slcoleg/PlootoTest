using Interfaces.Payment;

namespace Model.Payment;

/// <summary>
/// Payment record
/// </summary>
public class Payment : IPayment
{
  /// <summary>
  /// Gets or sets the identifier.
  /// </summary>
  /// <value>
  /// The identifier.
  /// </value>
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets the vendor identifier.
  /// </summary>
  /// <value>
  /// The vendor identifier.
  /// </value>
  public int VendorId { get; set; }

  /// <summary>
  /// Gets or sets the invoice identifier.
  /// </summary>
  /// <value>
  /// The invoice identifier.
  /// </value>
  public int InvoiceId { get; set; }

  /// <summary>
  /// Gets or sets the amount.
  /// </summary>
  /// <value>
  /// The amount.
  /// </value>
  public decimal Amount { get; set; }

  /// <summary>
  /// Gets or sets the debit date.
  /// </summary>
  /// <value>
  /// The debit date.
  /// </value>
  public DateTime DebitDate { get; set; }

  /// <summary>
  /// Gets or sets the payment information.
  /// </summary>
  /// <value>
  /// The payment information.
  /// </value>
  public string PaymentInfo { get; set; }

  /// <summary>
  /// Gets or sets the type of the payment.
  /// </summary>
  /// <value>
  /// The type of the payment.
  /// </value>
  public int PaymentType { get; set; }

  /// <summary>
  /// Gets or sets the status.
  /// </summary>
  /// <value>
  /// The status.
  /// </value>
  int Status { get; set; }
}
