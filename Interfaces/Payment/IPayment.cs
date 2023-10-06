namespace Interfaces.Payment;

/// <summary>
/// Payment definition
/// </summary>
public interface IPayment
{
  /// <summary>
  /// Gets or sets the identifier.
  /// </summary>
  /// <value>
  /// The identifier.
  /// </value>
  int Id { get; set; }

  /// <summary>
  /// Gets or sets the vendor identifier.
  /// </summary>
  /// <value>
  /// The vendor identifier.
  /// </value>
  int VendorId { get; set; }

  /// <summary>
  /// Gets or sets the invoice identifier.
  /// </summary>
  /// <value>
  /// The invoice identifier.
  /// </value>
  int InvoiceId { get; set; }

  /// <summary>
  /// Gets or sets the amount.
  /// </summary>
  /// <value>
  /// The amount.
  /// </value>
  decimal Amount { get; set; }

  /// <summary>
  /// Gets or sets the debit date.
  /// </summary>
  /// <value>
  /// The debit date.
  /// </value>
  DateTime DebitDate { get; set; }

  /// <summary>
  /// Gets or sets the type of the payment.
  /// </summary>
  /// <value>
  /// The type of the payment.
  /// </value>
  int PaymentType { get; set; }

  /// <summary>
  /// Gets or sets the state.
  /// </summary>
  /// <value>
  /// The state.
  /// </value>
  int State { get; set; }
}