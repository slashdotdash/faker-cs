using System;
using System.Text.RegularExpressions;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     What kind of image will be generated.
    /// </summary>
    public enum ImageFormat
    {
        // ReSharper disable InconsistentNaming        
        /// <summary>
        ///     A PNG image
        /// </summary>
        png,

        /// <summary>
        ///     A JPG image
        /// </summary>
        jpg,

        /// <summary>
        ///     A BMP image
        /// </summary>
        bmp
        // ReSharper restore InconsistentNaming
    }

    /// <summary>
    ///     A collection of Avatar related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="true" />
    public static class Avatar
    {
        /// <summary>
        ///     Gets a random image URL.
        /// </summary>
        /// <returns>The random image URL.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="set" /> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Size should be specified in format 300x300</exception>
        public static string Image(string slug = null, string size = "300x300", ImageFormat format = ImageFormat.png,
                                   string set = "set1")
        {
            if (set == null)
                throw new ArgumentNullException(nameof(set));
            if (!Regex.IsMatch(size, @"^[0-9]+x[0-9]+$"))
                throw new ArgumentException("Size should be specified in format 300x300");

            slug = slug ?? string.Join(string.Empty, Lorem.Words(3));

            return "http://robohash.org/{0}.{2}?size={1}&set={3}"
                .FormatCulture(slug,
                               size,
                               format,
                               set);
        }
    }
}
