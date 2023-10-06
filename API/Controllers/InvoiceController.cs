using DataAccess;
using DataAccess.Repository;
using Interfaces.Invoice;
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
public class InvoiceController : ControllerBase
{
  private readonly IInvoiceRepository _repo;
  private readonly ILogger<InvoiceController> _logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="InvoiceController" /> class.
  /// </summary>
  /// <param name="invoiceRepository">The invoice repository.</param>
  /// <param name="logger">The logger.</param>
  public InvoiceController(IInvoiceRepository invoiceRepository, ILogger<InvoiceController> logger)
  {
    _repo = invoiceRepository;
    _logger = logger;
  }

  /// <summary>
  /// Get list of vendors.
  /// </summary>
  /// <param name="state">The state.</param>
  /// <returns></returns>
  /// <example>
  /// GET: api/Vendor
  /// GET: api/Vendor/?activeOnly=false
  /// </example>
  [HttpGet]
  [ProducesResponseType(200, Type = typeof(IEnumerable<IInvoice>))]
  public async Task<ActionResult<IEnumerable<IInvoice>>> GetIncoices(int? state)
  {
    var list = await _repo.GetAllAsync(state);
    return Ok(list);
  }

  // GET: api/invoice/[id]
  /// <summary>
  /// Gets the invoice.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <returns></returns>
  [HttpGet("{id}", Name = nameof(GetInvoice))] // named route
  [ProducesResponseType(200, Type = typeof(IVendor))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<IInvoice>> GetInvoice(int id)
  {
    var c = await _repo.GetByIdAsync(id);
    if (c == null)
    {
      return NotFound(); // 404 Resource not found
    }
    return Ok(c); // 200 OK with customer in body
  }

}
