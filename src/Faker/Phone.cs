using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of Phone related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="false" />
    public static class Phone
    {
        /// <summary>
        ///     Generates a random phone number with a random pattern.
        /// </summary>
        /// <returns>The generated phone number.</returns>
        /// <seealso cref="Number(string)" />
        public static string Number()
        {
            return Number(Resources.Phone.Formats.Split(Config.SEPARATOR).Random());
        }

        /// <summary>
        ///     Generates a random phone number from the specified <paramref name="pattern" />.
        /// </summary>
        /// <param name="pattern">The pattern to generate a phone number from.</param>
        /// <returns>The generated phone number.</returns>
        public static string Number(string pattern)
        {
            return pattern.Trim().Numerify();
        }
    }
}
