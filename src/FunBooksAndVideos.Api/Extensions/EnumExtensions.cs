using System.ComponentModel;

namespace FunBooksAndVideos.Api.Extensions;

/// <summary>
///     Extension class for Enums.
/// </summary>
public static class EnumExtensions
{
    #region Public Methods

    /// <summary>
    ///     Return the contents of the <see cref="DescriptionAttribute" /> for the enum if available.
    /// </summary>
    /// <param name="value">The enum</param>
    /// <returns>The description string.</returns>
    public static string GetDescription(this Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[]) fi?.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false)!;

        return attributes?.Length > 0 ? attributes[0].Description : value.ToString();
    }

    #endregion
}