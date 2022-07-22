using System.ComponentModel;
using System.Text.Json.Serialization;

namespace FunBooksAndVideos.Api.Models;

/// <summary>
///     Defines a purchase order that may contain a product or membership request.
/// </summary>
public class PurchaseOrder
{
    #region Properties

    /// <summary>
    ///     The unique identifier of the customer.
    /// </summary>
    [JsonPropertyName("customer")]
    public int CustomerId { get; set; }

    /// <summary>
    ///     The Purchase Order ID
    /// </summary>
    [JsonPropertyName("purchaseOrder")]
    public int Id { get; set; }

    /// <summary>
    ///     The item lines associated with the order.
    /// </summary>
    [JsonPropertyName("itemLines")]
    public IList<ItemLine> ItemLines { get; set; } = new List<ItemLine>();

    /// <summary>
    ///     The total price of the purchase order.
    /// </summary>
    [JsonPropertyName("total")]
    public decimal TotalPrice { get; set; }

    #endregion
}

/// <summary>
///     An individual item line for a purchase
/// </summary>
/// <param name="Product"></param>
public record ItemLine(ProductType Product, string ProductName)
{
    //public override string ToString()
    //{
    //    return Product == ProductType.Membership
    //               ? ProductName
    //               : $"{Product.GetDescription()} \"{ProductName}\"";
    //}
}

/// <summary>
///     Product Types
/// </summary>
public enum ProductType
{
    [Description("Book")] Book,
    [Description("Video")] Video,
    Membership
}