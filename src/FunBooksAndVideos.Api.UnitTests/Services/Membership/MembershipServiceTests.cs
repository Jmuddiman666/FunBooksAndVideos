using FunBooksAndVideos.Api.Models;
using FunBooksAndVideos.Api.Services;

namespace FunBooksAndVideos.Api.UnitTests.Services.Membership;

/// <summary>
///     Tests the functionality of the <see cref="MembershipService" />.
/// </summary>
public class MembershipServiceTests : ITest<MembershipService>
{
    #region Public Methods

    public static IEnumerable<object[]> GetItemLines()
    {
        int Id = 3344656;
        int customerId = 4597890;
        yield return new object[] {( Id, customerId, new ItemLine(ProductType.Video, "Comprehensive First Aid Training") )};
        yield return new object[]
                     {
                         ( Id, customerId, new ItemLine(ProductType.Book, "The Girl on the train") )
                     };
    }

    /// <summary>
    ///     Given an item passed is not of type <see cref="ProductType.Membership" /> then
    ///     should throw an <see cref="ArgumentException" />.
    /// </summary>
    /// <returns></returns>
    [Theory]
    [MemberData(nameof(GetItemLines))]
    public async Task ThrowsExceptionGivenInvalidProductType((int id, int customerId, ItemLine itemLine) order)
    {
        //Arrange
        var sut = GetDefaultSystemUnderTest();

        //Act
        var func = () => sut.ActivateMembership(order);

        //Assert
        await Assert.ThrowsAsync<ArgumentException>(func);
    }

    #region Implementation of ITest<out MembershipService>

    /// <inheritdoc />
    public MembershipService GetDefaultSystemUnderTest()
    {
        var sut = new MembershipService();
        return sut;
    }

    #endregion

    #endregion
}