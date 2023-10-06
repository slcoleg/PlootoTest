using Interfaces;

namespace DataAccess.Repository
{
    public interface IPaymentRepository
  {
    Task<IEnumerable<IPayment>> GetAllAsync();
    Task<IPayment> GetByIdAsync(int id);
    Task<IEnumerable<IPayment>> AddAsync(IPayment[] payments);
  }
}