using Interfaces.Payment;

namespace DataAccess.Repository
{
  public interface IPaymentRepository
  {
    Task<bool> AddAsync(IPayment payment);
    Task<IEnumerable<IPayment>> GetAllAsync(int? state);
    Task<IPayment> GetByIdAsync(int id);
  }
}