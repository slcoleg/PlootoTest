namespace Model.Invoice;

/// <summary>
/// Vendor invoice
/// </summary>
public class Invoice : Interfaces.Invoice.IInvoice
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
  /// Gets or sets the due date.
  /// </summary>
  /// <value>
  /// The due date.
  /// </value>
  public DateOnly DueDate { get; set; }

  /// <summary>
  /// Gets or sets the issued date.
  /// </summary>
  /// <value>
  /// The issued date.
  /// </value>
  public DateOnly IssuedDate { get; set; }

  /// <summary>
  /// Gets or sets the amount.
  /// </summary>
  /// <value>
  /// The amount.
  /// </value>
  public decimal Amount { get; set; }

  /// <summary>
  /// Gets or sets the description.
  /// </summary>
  /// <value>
  /// The description.
  /// </value>
  public string Description { get; set; }
}
