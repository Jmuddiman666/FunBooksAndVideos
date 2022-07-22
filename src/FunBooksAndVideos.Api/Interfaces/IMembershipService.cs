using FunBooksAndVideos.Api.Models;

namespace FunBooksAndVideos.Api.Interfaces;

/// <summary>
///     Service to manage processing membership orders.
/// </summary>
public interface IMembershipService
{
    #region Public Methods

    /// <summary>
    ///     Activate the the requested membership
    /// </summary>
    Task ActivateMembership((int id, int customerId, ItemLine itemLine) purchaseOrder);

    #endregion
}