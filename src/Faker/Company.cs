using System;
using System.Diagnostics.CodeAnalysis;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of Company related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="false" />
    [SuppressMessage("ReSharper", "UseStringInterpolation")]
    public static class Company
    {
        /// <summary>
        ///     When a straight answer won't do, Bullshit to the rescue!
        /// </summary>
        /// <returns>Some <c>bullshit</c>.</returns>
        /// <remarks>
        ///     Wordlist originates from http://dack.com/web/bullshit.html
        /// </remarks>
        public static string Bullshit()
        {
            return string.Join(" ",
                               Resources.Company.BS1.Split(Config.SEPARATOR).Random(),
                               Resources.Company.BS2.Split(Config.SEPARATOR).Random(),
                               Resources.Company.BS3.Split(Config.SEPARATOR).Random());
        }

        /// <summary>
        ///     Generates a buzzword-laden catch phrase
        /// </summary>
        /// <returns>The buzzword-laden catch phrase.</returns>
        /// <remarks>
        ///     Wordlist originates from http://www.1728.com/buzzword.htm
        /// </remarks>
        public static string CatchPhrase()
        {
            return string.Join(" ",
                               Resources.Company.Buzzwords1.Split(Config.SEPARATOR).Random(),
                               Resources.Company.Buzzwords2.Split(Config.SEPARATOR).Random(),
                               Resources.Company.Buzzwords3.Split(Config.SEPARATOR).Random());
        }

        /// <summary>
        ///     Generates a random Company name
        /// </summary>
        /// <returns>The random company name.</returns>
        public static string Name()
        {
            return Resources.Company.NameFormats.RandomResource().Transform(true);
        }

        /// <summary>
        ///     Generates a random Company suffix.
        /// </summary>
        /// <returns>The random company suffix.</returns>
        public static string Suffix()
        {
            return Resources.Company.Suffix.Split(Config.SEPARATOR).Random();
        }
    }
}
