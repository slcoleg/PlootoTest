using DataAccess;
using DataAccess.Repository;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace AccountPayableAPI.Controllers;

/// <summary>
/// Vendor API
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
  private readonly IPaymentRepository _repo;
  private readonly ILogger<PaymentController> _logger;

  /// <summary>
  /// Initializes a new instance of the <see cref="PaymentController" /> class.
  /// </summary>
  /// <param name="paymentRepository">The Payment repository.</param>
  /// <param name="logger">The logger.</param>
  public PaymentController(IPaymentRepository paymentRepository, ILogger<PaymentController> logger)
  {
    _repo = paymentRepository;
    _logger = logger;
  }

  /// <summary>
  /// Get list of vendors.
  /// </summary>
  /// <returns></returns>
  /// <example>
  /// GET: api/Vendor
  /// GET: api/Vendor/?activeOnly=false
  /// </example>
  [HttpGet]
  [ProducesResponseType(200, Type = typeof(IEnumerable<IPayment>))]
  public async Task<ActionResult<IEnumerable<IPayment>>> GetPayments()
  {
    var list = await _repo.GetAllAsync();
    return Ok(list);
  }

  /// <summary>
  /// Gets the Payment.
  /// </summary>
  /// <param name="id">The identifier.</param>
  /// <example>
  /// GET: api/Payment/[id]
  /// </example>
  [HttpGet("{id}", Name = nameof(GetPayment))] // named route
  [ProducesResponseType(200, Type = typeof(IPayment))]
  [ProducesResponseType(404)]
  public async Task<ActionResult<IPayment>> GetPayment(int id)
  {
    var c = await _repo.GetByIdAsync(id);
    if (c == null)
    {
      return NotFound(); // 404 Resource not found
    }
    return Ok(c); // 200 OK with customer in body
  }

  /// <summary>
  /// Gets the Payment.
  /// </summary>
  /// <param name="payments">The list of payments.</param>
  /// <returns></returns>
  /// <example>
  /// PATCH: api/Payment/[id]?newState=[newState]
  /// </example>
  [HttpPost("Add", Name = nameof(AddPayments))] // named route
  [ProducesResponseType(200)]
  [ProducesResponseType(400)]
  [ProducesResponseType(404)]
  public async Task<ActionResult<IPayment>> AddPayments([FromBody] Payment[] payments)
  {
    var c = await _repo.AddAsync(payments);
    return c?.Count() > 0 ? Ok(c) : BadRequest();
  }

}
