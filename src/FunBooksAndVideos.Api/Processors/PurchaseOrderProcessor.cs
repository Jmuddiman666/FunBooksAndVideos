using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Processors;

/// <summary>
///     Processor to manage new purchase orders
/// </summary>
public class PurchaseOrderProcessor : IOrderProcessor
{
    #region Fields

    private readonly IMembershipService _membershipService;
    private readonly IProductService _productService;

    #endregion

    #region Constructors

    public PurchaseOrderProcessor(IMembershipService membershipService, IProductService productService)
    {
        _membershipService = membershipService;
        _productService = productService;
    }

    #endregion

    #region Public Methods

    /// <summary>
    ///     Process a <see cref="PurchaseOrder" />. Memberships will be activated immediately or product order shipping slips
    ///     generated.
    /// </summary>
    /// <param name="purchaseOrder"></param>
    /// <returns></returns>
    public async Task ProcessOrder(PurchaseOrder purchaseOrder)
    {
        //Check order is valid
        if (!purchaseOrder.ItemLines.Any()) throw new("No items to process");


        foreach (var itemLine in purchaseOrder.ItemLines.ToList())
        {
            switch (itemLine.Product)
            {
                case ProductType.Book:
                case ProductType.Video:
                    await _productService.GenerateShippingSlip(new ValueTuple<int, int, ItemLine>(purchaseOrder.Id, purchaseOrder.CustomerId, itemLine));
                    break;
                case ProductType.Membership:
                    await _membershipService.ActivateMembership(new ValueTuple<int, int, ItemLine>(purchaseOrder.Id, purchaseOrder.CustomerId, itemLine));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    #endregion
}