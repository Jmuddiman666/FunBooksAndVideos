using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Interfaces;

/// <summary>
///     Service to manage product orders
/// </summary>
public interface IProductService
{
    #region Public Methods

    /// <summary>
    ///     Generate a new shipping slip for the request purchase.
    /// </summary>
    /// <param name="purchaseOrder">The purchase order to process.</param>
    Task GenerateShippingSlip((int id, int customerId, ItemLine itemLine) purchaseOrder);

    #endregion
}