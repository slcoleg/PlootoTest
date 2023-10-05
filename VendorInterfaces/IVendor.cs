using System.Collections.Generic;

namespace AccountPayableVendorInterfaces
{
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
    string Address { get; set; }
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
    /// Gets or sets the payment settimgs.
    /// </summary>
    /// <value>
    /// The payment settimgs.
    /// </value>
    public List<IVendorPayment> PaymentSettimgs { get; set; }
  }
}