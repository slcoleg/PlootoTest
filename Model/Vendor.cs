using Interfaces.Vendor;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

/// <summary>
/// Vendor
/// </summary>
/// <seealso cref="IVendor" />
public class Vendor : IVendor
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
  /// Gets or sets the name.
  /// </summary>
  /// <value>
  /// The name.
  /// </value>
  [Required]
  [StringLength(50)]
  public string Name { get; set; }

  /// <summary>
  /// Gets or sets the description.
  /// </summary>
  /// <value>
  /// The description.
  /// </value>
  [StringLength(250)]
  public string Description { get; set; }

  /// <summary>
  /// Gets or sets the address.
  /// </summary>
  /// <value>
  /// The address.
  /// </value>
  [Required]
  [StringLength(250)]
  public string Address { get; set; }

  /// <summary>
  /// Gets or sets the state.
  /// </summary>
  /// <value>
  /// The state.
  /// </value>
  [Required]
  public int State { get; set; } = 1;

  /// <summary>
  /// Gets or sets the modified.
  /// </summary>
  /// <value>
  /// The modified.
  /// </value>
  [Required]
  [DataType(DataType.Date)]
  public DateTime Modified { get; set; } = DateTime.Now;
}