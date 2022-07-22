using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Services;

namespace FunBooksAndVideos.Api.UnitTests.Services.Product;

/// <summary>
///     Tests the functionality of the <see cref="ProductService" />.
/// </summary>
public class ProductServiceTests : ITest<ProductService>
{
    #region Public Methods

    /// <summary>
    ///     Given an invalid type that is neither <see cref="ProductType.Book" /> nor <seealso cref="ProductType.Video" />
    ///     then throw an argument exception.
    /// </summary>
    /// <returns></returns>
    [Fact]
    public async Task ThrowsArgumentExceptionGivenInvalidProduct()
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();
        (int id, int customerId, ItemLine itemLine) fakeOrder = new(3344656, 4567890, new(ProductType.Membership, "Book Club Membership"));


        //Act
        var func = () => sut.GenerateShippingSlip(fakeOrder);

        //Assert
        await Assert.ThrowsAsync<ArgumentException>(func);
    }

    #region Implementation of ITest<out ProductService>

    /// <inheritdoc />
    public ProductService GetDefaultSystemUnderTest()
    {
        var sut = new ProductService();
        return sut;
    }

    #endregion

    #endregion
}