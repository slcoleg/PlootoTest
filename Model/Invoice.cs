using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Interfaces;

namespace Model;

/// <summary>
/// Vendor invoice
/// </summary>
public class Invoice : IInvoice
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
  /// Gets or sets the due date.
  /// </summary>
  /// <value>
  /// The due date.
  /// </value>
  [Required]
  [DataType(DataType.DateTime)]
  public DateTime DueDate { get; set; }

  /// <summary>
  /// Gets or sets the issued date.
  /// </summary>
  /// <value>
  /// The issued date.
  /// </value>
  [Required]
  [DataType(DataType.DateTime)]
  public DateTime IssuedDate { get; set; }

  /// <summary>
  /// Gets or sets the amount.
  /// </summary>
  /// <value>
  /// The amount.
  /// </value>
  [Required]
  [DataType(DataType.Currency)]
  public decimal Amount { get; set; }

  /// <summary>
  /// Gets or sets the state.
  /// </summary>
  /// <value>
  /// The state.
  /// </value>
  [Required]
  public int State { get; set; } = 0;

  /// <summary>
  /// Gets or sets the description.
  /// </summary>
  /// <value>
  /// The description.
  /// </value>
  public string Description { get; set; }
}
