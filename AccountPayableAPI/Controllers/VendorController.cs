using AccountPayableVendorInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountPayableAPI.Controllers;

/// <summary>
/// Vendor API
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{
  private readonly ILogger<VendorController> _logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="VendorController"/> class.
  /// </summary>
  /// <param name="logger">The logger.</param>
  public VendorController(ILogger<VendorController> logger)
  {
    _logger = logger;
  }

  /// <summary>
  /// Gets the vendors.
  /// </summary>
  /// <returns></returns>
  [HttpGet("/")]
  public IEnumerable<List<IVendor>> GetVendors()
  {
    return null;
  }
}
