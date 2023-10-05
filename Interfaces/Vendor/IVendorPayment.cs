namespace Interfaces.Vendor;

/// <summary>
/// Payment definition
/// </summary>
public interface IVendorPayment
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>

    int Id { get; set; }
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>

    string Name { get; set; }
    /// <summary>
    /// Gets or sets the payment information.
    /// </summary>
    /// <value>
    /// The payment information.
    /// </value>

    string PaymentInfo { get; set; }
    /// <summary>
    /// Gets or sets the type of the payment.
    /// </summary>
    /// <value>
    /// The type of the payment.
    /// </value>
    int PaymentType { get; set; }
}