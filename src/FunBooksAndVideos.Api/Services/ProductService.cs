using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Services;

/// <inheritdoc />
public class ProductService : IProductService
{
    #region Public Methods

    #region Implementation of IProductService

    /// <inheritdoc />
    public async Task GenerateShippingSlip((int id, int customerId, ItemLine itemLine) purchaseOrder)
    {
        if (purchaseOrder.itemLine.Product != ProductType.Book &&
            purchaseOrder.itemLine.Product != ProductType.Video)
            throw new ArgumentException("Invalid type");
        //send details to a queue for processing
    }

    #endregion

    #endregion
}