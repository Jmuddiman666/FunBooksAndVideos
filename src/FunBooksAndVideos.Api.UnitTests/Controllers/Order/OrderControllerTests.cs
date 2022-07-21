using FunBooksAndVideos.Api.Controllers;
using FunBooksAndVideos.Api.Interfaces;
using FunBooksAndVideos.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FunBooksAndVideos.Api.UnitTests.Controllers.Order;

public class OrderControllerTests : ITest<OrderController>
{
    #region Fields

    private readonly Mock<IOrderProcessor> _mockOrderProcessor;

    #endregion

    #region Constructors

    public OrderControllerTests()
    {
        _mockOrderProcessor = new Mock<IOrderProcessor>();
    }

    #endregion

    #region Properties

    private PurchaseOrder GetPurchaseOrder => new()
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
    ///     Given a successful request, should return a <see cref="StatusCodeResult" />
    ///     <see cref="StatusCodes.Status202Accepted" />
    /// </summary>
    [Fact]
    public async Task ShouldReturnAcceptedResult()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var fakePo = GetPurchaseOrder;
        //Act
        object actionResult = await sut.CreateOrder(fakePo);

        //Assert
        var objectResult = Assert.IsAssignableFrom<StatusCodeResult>(actionResult);
        Assert.Equal(StatusCodes.Status202Accepted, objectResult.StatusCode);
    }

    /// <summary>
    ///     Given a valid request, the purchase order should be send to an <see cref="IOrderProcessor" />.
    /// </summary>
    [Fact]
    public async Task ShouldSendPoToOrderProcessor()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        var fakePo = GetPurchaseOrder;
        _mockOrderProcessor.Setup(x => x.ProcessOrder(fakePo)).Verifiable();

        //Act
        await sut.CreateOrder(fakePo);

        //Assert
        _mockOrderProcessor.Verify(x => x.ProcessOrder(fakePo));
    }

    #region Implementation of ITest<out OrderController>

    /// <inheritdoc />
    public OrderController GetDefaultSystemUnderTest()
    {
        var sut = new OrderController(_mockOrderProcessor.Object);
        return sut;
    }

    #endregion

    #endregion
}