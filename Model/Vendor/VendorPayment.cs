using Interfaces.Vendor;

namespace Model.Vendor
{
    /// <summary>
    /// Payment method definition
    /// </summary>
    /// <seealso cref="Interfaces.Vendor.IVendorPayment" />
    public class VendorPayment : IVendorPayment
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
    /// Gets or sets the type of the payment.
    /// </summary>
    /// <value>
    /// The type of the payment.
    /// </value>
    public int PaymentType { get; set; }
    
    /// <summary>
    /// Gets or sets the payment information.
    /// </summary>
    /// <value>
    /// The payment information.
    /// </value>
    public string PaymentInfo { get; set; }
  }
}