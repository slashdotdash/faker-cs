using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of Phone related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="true" />
    public static class Phone
    {
        /// <summary>
        ///     Gets a random cell phone number.
        /// </summary>
        /// <returns>The generated cell phone number.</returns>
        public static string CellNumber()
        {
            return Number(Resources.Phone.CellPhoneFormats.RandomResource());
        }

        /// <summary>
        ///     Generates a random extension with a length of 4. (US based)
        /// </summary>
        /// <returns>a random extension.</returns>
        public static string Extension()
        {
            return Extension(4);
        }

        /// <summary>
        ///     Generates a random extension with the specified <paramref name="length" />. (US based)
        /// </summary>
        /// <returns>a random extension.</returns>
        public static string Extension(int length)
        {
            return string.Concat(length.Times(i => RandomNumber.Next(0, 10)));
        }

        /// <summary>
        ///     Generates a random phone number with a random pattern.
        /// </summary>
        /// <returns>The generated phone number.</returns>
        /// <seealso cref="Number(string)" />
        public static string Number()
        {
            return Number(Resources.Phone.Formats.RandomResource());
        }

        /// <summary>
        ///     Generates a random phone number from the specified <paramref name="pattern" />.
        /// </summary>
        /// <param name="pattern">The pattern to generate a phone number from.</param>
        /// <returns>The generated phone number.</returns>
        public static string Number(string pattern)
        {
            return pattern.Trim().Numerify(true);
        }

        /// <summary>
        ///     Generates a random Subscriber number. (US Based).
        /// </summary>
        /// <returns>A random subscriber number.</returns>
        public static string SubscriberNumber()
        {
            return Extension(4);
        }
    }
}