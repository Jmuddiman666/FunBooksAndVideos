using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Interfaces;

/// <summary>
///     Processor to manage new purchase orders
/// </summary>
public interface IOrderProcessor
{
    #region Public Methods

    /// <summary>
    ///     Process a <see cref="PurchaseOrder" />. Memberships will be activated immediately or product order shipping slips
    ///     generated.
    /// </summary>
    /// <param name="purchaseOrder"></param>
    /// <returns></returns>
    Task ProcessOrder(PurchaseOrder purchaseOrder);

    #endregion
}