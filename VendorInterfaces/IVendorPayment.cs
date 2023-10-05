namespace AccountPayableVendorInterfaces
{
  public interface IVendorPayment
  {
    int Id { get; set; }
    string Name { get; set; }
    string PaymentInfo { get; set; }
    int PaymentType { get; set; }
  }
}