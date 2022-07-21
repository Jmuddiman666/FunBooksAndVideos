using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace FunBooksAndVideos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    #region Fields

    private readonly IOrderProcessor _orderProcessor;

    #endregion

    #region Constructors

    /// <inheritdoc />
    public OrderController(IOrderProcessor orderProcessor)
    {
        _orderProcessor = orderProcessor;
    }

    #endregion

    #region Public Methods

    /// <summary>
    ///     Create a new purchase order.
    /// </summary>
    /// <param name="purchaseOrder"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public async Task<IActionResult> CreateOrder(PurchaseOrder purchaseOrder)
    {
        await _orderProcessor.ProcessOrder(purchaseOrder);
        return new StatusCodeResult(StatusCodes.Status202Accepted);
    }

    #endregion
}