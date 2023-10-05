using Interfaces.Vendor;

namespace Model.Vendor;

/// <summary>
/// Vendor
/// </summary>
/// <seealso cref="Interfaces.Vendor.IVendor" />
public class Vendor : IVendor
{
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
  /// Gets or sets the description.
  /// </summary>
  /// <value>
  /// The description.
  /// </value>
  public string Description { get; set; }

  /// <summary>
  /// Gets or sets the address.
  /// </summary>
  /// <value>
  /// The address.
  /// </value>
  public string Address { get; set; }

  /// <summary>
  /// Gets or sets the payment settimgs.
  /// </summary>
  /// <value>
  /// The payment settimgs.
  /// </value>
  public List<IVendorPayment> PaymentSettimgs { get; set; } = new List<IVendorPayment>();
}