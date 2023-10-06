using System.Collections.Generic;

namespace Interfaces.Vendor;

/// <summary>
/// Vendor Interface
/// </summary>
public interface IVendor
{
  /// <summary>
  /// Gets or sets the address.
  /// </summary>
  /// <value>
  /// The address.
  /// </value>
  public string Address { get; set; }
  /// <summary>
  /// Gets or sets the description.
  /// </summary>
  /// <value>
  /// The description.
  /// </value>
  public string Description { get; set; }

  /// <summary>
  /// Gets or sets the identifier.
  /// </summary>
  /// <value>
  /// The identifier.
  /// </value>
  public int Id { get; set; }

  /// <summary>
  /// Gets or sets the name.
  /// </summary>
  /// <value>
  /// The name.
  /// </value>
  public string Name { get; set; }

  /// <summary>
  /// Gets or sets the state.
  /// </summary>
  /// <value>
  /// The state.
  /// </value>
  public int State { get; set; }

  /// <summary>
  /// Gets or sets the modified.
  /// </summary>
  /// <value>
  /// The modified.
  /// </value>
  public DateTime Modified { get; set; }
}