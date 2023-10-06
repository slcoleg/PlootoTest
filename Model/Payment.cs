using Interfaces.Payment;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

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
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets the vendor identifier.
  /// </summary>
  /// <value>
  /// The vendor identifier.
  /// </value>
  [Required]
  public int VendorId { get; set; }

  /// <summary>
  /// Gets or sets the invoice identifier.
  /// </summary>
  /// <value>
  /// The invoice identifier.
  /// </value>
  [Required]
  public int InvoiceId { get; set; }

  /// <summary>
  /// Gets or sets the amount.
  /// </summary>
  /// <value>
  /// The amount.
  /// </value>
  [Required]
  public decimal Amount { get; set; }

  /// <summary>
  /// Gets or sets the debit date.
  /// </summary>
  /// <value>
  /// The debit date.
  /// </value>
  [Required]
  public DateTime DebitDate { get; set; }


  /// <summary>
  /// Gets or sets the type of the payment.
  /// </summary>
  /// <value>
  /// The type of the payment.
  /// </value>
  [Required]
  [Range(0, 2)]
  public int PaymentType { get; set; }

  /// <summary>
  /// Gets or sets the status.
  /// </summary>
  /// <value>
  /// The status.
  /// </value>
  [Required]
  [Range(0, 2)]
  public int State { get; set; }
}
