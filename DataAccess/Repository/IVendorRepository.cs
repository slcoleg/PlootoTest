using Interfaces.Vendor;

namespace DataAccess.Repository
{
  public interface IVendorRepository
  {
    Task<IEnumerable<IVendor>> GetAllAsync(bool active = true);
    Task<IVendor> GetByIdAsync(int id);
  }
}