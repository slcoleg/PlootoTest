namespace Interfaces.Invoice;

/// <summary>
/// Invoice interface
/// </summary>
public interface IInvoice
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
  /// Gets or sets the amount.
  /// </summary>
  /// <value>
  /// The amount.
  /// </value>
  decimal Amount { get; set; }

  /// <summary>
  /// Gets or sets the description.
  /// </summary>
  /// <value>
  /// The description.
  /// </value>
  string Description { get; set; }

  /// <summary>
  /// Gets or sets the due date.
  /// </summary>
  /// <value>
  /// The due date.
  /// </value>
  DateOnly DueDate { get; set; }

  /// <summary>
  /// Gets or sets the issued date.
  /// </summary>
  /// <value>
  /// The issued date.
  /// </value>
  DateOnly IssuedDate { get; set; }

  /// <summary>
  /// Gets or sets the state of invoice.
  /// </summary>
  /// <value>
  /// The status.
  /// </value>
  int State { get; set; }
}