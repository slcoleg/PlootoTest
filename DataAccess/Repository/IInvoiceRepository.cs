using Interfaces;

namespace DataAccess.Repository
{
    public interface IInvoiceRepository
  {
    Task<IEnumerable<IInvoice>> GetAllAsync(int? state);
    Task<IInvoice> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, int state);
  }
}