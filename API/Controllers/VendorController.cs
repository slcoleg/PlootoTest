using DataAccess;
using DataAccess.Repository;
using Interfaces.Vendor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountPayableAPI.Controllers;

/// <summary>
/// Vendor API
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[ApiController]
[Route("api/[controller]")]
public class VendorController : ControllerBase
{
  private readonly IVendorRepository _repo;
  private readonly ILogger<VendorController> _logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="VendorController" /> class.
  /// </summary>
  /// <param name="vendorRepository">The vendor repository.</param>
  /// <param name="logger">The logger.</param>
  public VendorController(IVendorRepository vendorRepository, ILogger<VendorController> logger)
  {
    _repo = vendorRepository;
    _logger = logger;
  }

  /// <summary>
  /// Get list of vendors.
  /// </summary>
  /// <param name="activeOnly">The active only. Default is false</param>
  /// <returns></returns>
  /// <example>
  /// GET: api/Vendor
  /// GET: api/Vendor/?activeOnly=false
  /// </example>
  [HttpGet]
  [ProducesResponseType(200, Type = typeof(IEnumerable<IVendor>))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<IEnumerable<IVendor>>> GetVendors(bool? activeOnly)
  {
    var list = await _repo.GetAllAsync(activeOnly ?? false);
    return Ok(list);
  }
}
