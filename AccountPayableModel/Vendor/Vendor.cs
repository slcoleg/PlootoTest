using AccountPayableVendorInterfaces;

namespace AccountPayableModel.Vendor;

public class Vendor : IVendor
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Address { get; set; }
  public List<IVendorPayment> PaymentSettimgs { get; set; } = new List<IVendorPayment>();
}