using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Processors;
using Moq;

namespace FunBooksAndVideos.Api.UnitTests.Processors.PurchaseOrder;

/// <summary>
///     Tests the functionality of the <see cref="PurchaseOrderProcessor" /> class.
/// </summary>
public class PurchaseOrderProcessorTests : ITest<PurchaseOrderProcessor>
{
    #region Fields

    private readonly Mock<IMembershipService> _membershipServiceMock;
    private readonly Mock<IProductService> _productServiceMock;

    #endregion

    #region Constructors

    public PurchaseOrderProcessorTests()
    {
        _membershipServiceMock = new();
        _productServiceMock = new();
    }

    #endregion

    #region Properties

    private Models.PurchaseOrder GetPurchaseOrder => new()
                                                     {
                                                         Id = 3344656,
                                                         TotalPrice = 48.50M,
                                                         CustomerId = 4567890,
                                                         ItemLines = new List<ItemLine>
                                                                     {
                                                                         new(ProductType.Video, "Comprehensive First Aid Training"),
                                                                         new(ProductType.Book, "The Girl on the train"),
                                                                         new(ProductType.Membership, "Book Club Membership")
                                                                     }
                                                     };

    #endregion

    #region Public Methods

    /// <summary>
    ///     Given the provided <see cref="PurchaseOrder" /> contains a <see cref="Models.ProductType.Membership" />
    ///     then the membership service should be called to active it immediately.
    /// </summary>
    /// <remarks>
    ///     BR 1
    /// </remarks>
    [Fact]
    public async Task ActivateMembershipOrders()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var fakeOrder = new Models.PurchaseOrder
                        {
                            Id = 3344656,
                            TotalPrice = 48.50M,
                            CustomerId = 4567890,
                            ItemLines = new List<ItemLine>
                                        {
                                            new(ProductType.Membership, "Book Club Membership")
                                        }
                        };
        (int id, int customerId, ItemLine itemLine) request = new(fakeOrder.Id, fakeOrder.CustomerId, fakeOrder.ItemLines[0]);
        _membershipServiceMock.Setup(x => x.ActivateMembership(request))
                              .Verifiable();

        //Act
        await sut.ProcessOrder(fakeOrder);

        //Assert
        _membershipServiceMock.Verify(x => x.ActivateMembership(request),
                                      Times.Once);
        _productServiceMock.Verify(x => x.GenerateShippingSlip(request), Times.Never);
    }


    /// <summary>
    ///     Given the provided <see cref="PurchaseOrder" /> contains a <see cref="Models.ProductType.Book" /> or
    ///     <seealso cref="Models.ProductType.Video" />
    ///     then a shipping must be created.
    /// </summary>
    /// <remarks>
    ///     BR2
    /// </remarks>
    [Fact]
    public async Task GenerateShippingSlip()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var fakeOrder = new Models.PurchaseOrder
                        {
                            Id = 3344656,
                            TotalPrice = 48.50M,
                            CustomerId = 4567890,
                            ItemLines = new List<ItemLine>
                                        {
                                            new(ProductType.Video, "Comprehensive First Aid Training"),
                                            new(ProductType.Book, "The Girl on the train")
                                        }
                        };
        (int id, int customerId, ItemLine itemLine) request = new(fakeOrder.Id, fakeOrder.CustomerId, fakeOrder.ItemLines[0]);
        _productServiceMock.Setup(x => x.GenerateShippingSlip(request)).Verifiable();

        //Act
        await sut.ProcessOrder(fakeOrder);

        //Assert
        _membershipServiceMock.Verify(x => x.ActivateMembership(new ValueTuple<int, int, ItemLine>(fakeOrder.Id, fakeOrder.CustomerId, It.IsAny<ItemLine>())),
                                      Times.Never);
        _productServiceMock.Verify(x => x.GenerateShippingSlip(request), Times.AtLeastOnce);
    }

    #region Implementation of ITest<out PurchaseOrderProcessor>

    /// <inheritdoc />
    public PurchaseOrderProcessor GetDefaultSystemUnderTest()
    {
        var sut = new PurchaseOrderProcessor(_membershipServiceMock.Object, _productServiceMock.Object);
        return sut;
    }

    #endregion

    #endregion
}