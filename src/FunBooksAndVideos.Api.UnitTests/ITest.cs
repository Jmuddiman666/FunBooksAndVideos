namespace FunBooksAndVideos.Api.UnitTests;

/// <summary>
///     Test interface to standardize implementation of tests.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ITest<out T>
{
    #region Public Methods

    /// <summary>
    ///     Return the default instance of <typeparamref name="T" />
    /// </summary>
    /// <returns></returns>
    T GetDefaultSystemUnderTest();

    #endregion
}