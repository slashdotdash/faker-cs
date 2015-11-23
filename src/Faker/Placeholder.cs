using System;
using System.Text.RegularExpressions;

namespace Faker
{
    /// <summary>
    ///     What kind of placeholdit image will be generated.
    /// </summary>
    public enum PlaceholditImageFormat
    {
        /// <summary>
        ///     A GIF image
        /// </summary>
        gif,

        /// <summary>
        ///     A JPEG image
        /// </summary>
        jpeg,

        /// <summary>
        ///     A JPG image
        /// </summary>
        jpg,

        /// <summary>
        ///     A PNG image
        /// </summary>
        png
    }

    /// <summary>
    ///     A collection of Placeholder related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="true" />
    public static class Placeholder
    {
        /// <summary>
        ///     Generates a url pointing to the website placehold.it.
        /// </summary>
        /// <param name="size">The size of the image</param>
        /// <param name="format">The format the image</param>
        /// <param name="backgroundColor">The image background color.</param>
        /// <param name="textColor">The image text/foreground color.</param>
        /// <param name="text">The text on the image.</param>
        /// <returns>The generated image.</returns>
        /// <exception cref="ArgumentException">
        ///     <para>
        ///         If the <paramref name="size" /> is not in the format '300' and not in the format '300x300'.
        ///     </para>
        ///     <para>
        ///         If the background color is not a hex color value without '#'
        ///     </para>
        ///     <para>
        ///         If the text color is not a hex color value without '#'
        ///     </para>
        /// </exception>
        public static string Placeholdit(
            string size = "300x300",
            PlaceholditImageFormat format = PlaceholditImageFormat.png,
            string backgroundColor = null,
            string textColor = null,
            string text = null)
        {
            if (!Regex.IsMatch(size, @"^[0-9]+(x[0-9]+)?$"))
                throw new ArgumentException("size should be specified in format '300' or '300x300", "size");
            var regex = new Regex("^(?:[A-Fa-f0-9]{3}|[A-fa-f0-9]{6})$");
            if (backgroundColor != null && !regex.IsMatch(backgroundColor))
                throw new ArgumentException("backgroundColor must be a hex value without '#'", "backgroundColor");
            if (textColor != null && !regex.IsMatch(textColor))
                throw new ArgumentException("textColor must be a hex value without '#'", "textColor");

            var imageUrl = "https://placehold.it/" + size;
            if (!string.IsNullOrEmpty(backgroundColor))
                imageUrl += "/" + backgroundColor;
            if (!string.IsNullOrEmpty(textColor))
            {
                if (string.IsNullOrEmpty(backgroundColor))
                    imageUrl += "/D3D3D3";
                imageUrl += "/" + textColor;
            }
            imageUrl += "." + format;
            if (!string.IsNullOrEmpty(text))
                imageUrl += "?text=" + text;

            return imageUrl;
        }
    }
}