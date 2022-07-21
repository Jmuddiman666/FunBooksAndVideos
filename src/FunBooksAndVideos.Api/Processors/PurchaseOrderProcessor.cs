using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Processors;

/// <summary>
///     Processor to manage new purchase orders
/// </summary>
public class PurchaseOrderProcessor : IOrderProcessor
{
    #region Public Methods

    /// <summary>
    ///     Process a <see cref="PurchaseOrder" />. Memberships will be activated immediately or product order shipping slips
    ///     generated.
    /// </summary>
    /// <param name="purchaseOrder"></param>
    /// <returns></returns>
    public async Task ProcessOrder(PurchaseOrder purchaseOrder)
    {
    }

    #endregion
}