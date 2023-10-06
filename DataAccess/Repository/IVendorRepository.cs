using Interfaces;

namespace DataAccess.Repository
{
    public interface IVendorRepository
  {
    Task<IEnumerable<IVendor>> GetAllAsync();
    Task<IVendor> GetByIdAsync(int id);
  }
}