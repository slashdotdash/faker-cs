using System.Globalization;
using System.Text.RegularExpressions;

namespace Faker.Extensions
{
    /// <summary>
    ///     A collection of string helper extensions.
    /// </summary>
    public static class StringExtensions
    {
        private const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        ///     Removes all characters which is not Alphanumeric from the specified <paramref name="s">source</paramref>
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <returns>The transformed string.</returns>
        public static string AlphanumericOnly(this string s)
        {
            return Regex.Replace(s, @"\W", string.Empty);
        }

        /// <summary>
        ///     Capitalises the first letter of the given string.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <returns>The source string with it's first letter capitalized.</returns>
        public static string Capitalise(this string s)
        {
            return Regex.Replace(s, "^[a-z]", x => x.Value.ToUpperInvariant());
        }

        /// <summary>
        ///     Get a string with every '?' replaced with a random character from the english alphabet.
        /// </summary>
        /// <param name="s">The source format</param>
        /// <returns>The formatted string.</returns>
        public static string Letterify(this string s)
        {
            return Regex.Replace(s, @"\?", m => ALPHABET.Random().ToString());
        }

        /// <summary>
        ///     Get a string with every occurrence of '#' replaced with a random number.
        /// </summary>
        /// <param name="s">The source format.</param>
        /// <returns>The formatted string.</returns>
        public static string Numerify(this string s)
        {
            return Regex.Replace(s, "#", m => RandomNumber.Next(0, 9).ToString(CultureInfo.CurrentCulture));
        }
    }
}
