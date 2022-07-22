using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Services;

/// <inheritdoc />
public class MembershipService : IMembershipService
{
    #region Public Methods

    #region Implementation of IMembershipService

    /// <inheritdoc />
    public async Task ActivateMembership((int id, int customerId, ItemLine itemLine) purchaseOrder)
    {
        if (purchaseOrder.itemLine.Product != ProductType.Membership)
            throw new ArgumentException(nameof(purchaseOrder.itemLine.Product));
        //Update a repository
    }

    #endregion

    #endregion
}