namespace AccountPayableModel.Vendor
{
  public class VendorPayment : IVendorPayment
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public PaymentType PaymentType { get; set; }
    public string PaymentInfo { get; set; }
  }
}