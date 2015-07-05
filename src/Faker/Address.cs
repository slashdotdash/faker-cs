using System;
using System.Collections.Generic;
using System.Globalization;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of address related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="false" />
    public static class Address
    {
        #region Random Example

        /// <summary>
        ///     Gets a random city.
        /// </summary>
        /// <returns>The random city.</returns>
        public static string City()
        {
            return s_cityFormats.Random();
        }

        #endregion

        /// <summary>
        ///     Gets a random city prefix.
        /// </summary>
        /// <returns>The random city prefix.</returns>
        public static string CityPrefix()
        {
            return Resources.Address.CityPrefix.Split(Config.SEPARATOR).Random();
        }

        /// <summary>
        ///     Gets a random city suffix.
        /// </summary>
        /// <returns>The city suffix.</returns>
        public static string CitySuffix()
        {
            return Resources.Address.CityPrefix.Split(Config.SEPARATOR).Random();
        }

        /// <inheritdoc cref="CitySuffix()" />
        /// <remarks>
        ///     <include file='Docs/CustomRemarks.xml' path='Comments/ConfigSeparator/remarks/note[@type="warning"]' />
        ///     <note type="tip">
        ///         Use <see cref="CitySuffix()" /> instead.
        ///     </note>
        /// </remarks>
        /// <seealso cref="CitySuffix()" />
        [Obsolete("This method is obsolete. Call CitySuffix instead", true)]
        public static string CitySufix()
        {
            return CitySuffix();
        }

        /// <summary>
        ///     Gets a random country.
        /// </summary>
        /// <returns>The random country.</returns>
        public static string Country()
        {
            return Resources.Address.Country.Split(Config.SEPARATOR).Random().Trim();
        }

        /// <summary>
        ///     Gets a random secondary address.
        /// </summary>
        /// <returns>A random secondary address.</returns>
        public static string SecondaryAddress()
        {
            return Resources.Address.SecondaryAddress.Split(Config.SEPARATOR).Random().Trim().Numerify();
        }

        /// <summary>
        ///     Gets a random street address, without a Secondary address.
        /// </summary>
        /// <returns>A random street address, without a secondary address.</returns>
        public static string StreetAddress()
        {
            return StreetAddress(false);
        }

        /// <summary>
        ///     Gets a random street address.
        /// </summary>
        /// <param name="includeSecondaryAddress">if set to <see langword="true" /> include secondary address.</param>
        /// <returns>A random street address.</returns>
        public static string StreetAddress(bool includeSecondaryAddress)
        {
            return s_streetAddressFormats.Random().Trim().Numerify()
                   + (includeSecondaryAddress ? " " + SecondaryAddress() : string.Empty);
        }

        /// <summary>
        ///     Gets the name of a random street.
        /// </summary>
        /// <returns>The name of a random street.</returns>
        public static string StreetName()
        {
            return string.Join(Resources.Address.StreetNameSeparator, s_streetFormats.Random());
        }

        /// <summary>
        ///     Gets a random street suffix.
        /// </summary>
        /// <returns>The random street suffix.</returns>
        public static string StreetSuffix()
        {
            return Resources.Address.StreetSuffix.Split(Config.SEPARATOR).Random();
        }

        /// <summary>
        ///     Gets a random uk country.
        /// </summary>
        /// <returns>A random uk country.</returns>
        public static string UkCountry()
        {
            return Resources.Address.UkCountry.Split(Config.SEPARATOR).Random().Trim();
        }

        /// <summary>
        ///     Gets a random uk county.
        /// </summary>
        /// <returns>A random uk country.</returns>
        public static string UkCounty()
        {
            return Resources.Address.UkCounties.Split(Config.SEPARATOR).Random().Trim();
        }

        /// <summary>
        ///     Gets a random uk postal code.
        /// </summary>
        /// <returns>A random uk postal code.</returns>
        public static string UkPostCode()
        {
            return Resources.Address.UkPostCode.Split(Config.SEPARATOR).Random().Trim().Numerify().Letterify();
        }

        /// <summary>
        ///     Gets a random state int America.
        /// </summary>
        /// <returns>The random state in America.</returns>
        public static string UsState()
        {
            return Resources.Address.UsState.Split(Config.SEPARATOR).Random().Trim();
        }

        /// <summary>
        ///     Gets a random state abbreviation in America.
        /// </summary>
        /// <returns>The random state abbreviation in America.</returns>
        public static string UsStateAbbr()
        {
            return Resources.Address.UsStateAbbr.Split(Config.SEPARATOR).Random().Trim();
        }

        /// <summary>
        ///     Gets a random zip code.
        /// </summary>
        /// <returns>The random zip code.</returns>
        public static string ZipCode()
        {
            return Resources.Address.ZipCode.Split(Config.SEPARATOR).Random().Trim().Numerify();
        }

        #region Format Mappings

        private static readonly IEnumerable<Func<string>> s_cityFormats = new Func<string>[]
        {
            () => string.Format(CultureInfo.CurrentCulture, "{0} {1}{2}", CityPrefix(), Name.First(), CitySuffix()),
            () => string.Format(CultureInfo.CurrentCulture, "{0} {1}", CityPrefix(), Name.First()),
            () => Name.First() + CitySuffix(),
            () => Name.Last() + CitySuffix()
        };

        private static readonly IEnumerable<Func<string[]>> s_streetFormats = new Func<string[]>[]
        {
            () => new[] {Name.Last(), StreetSuffix()},
            () => new[] {Name.First(), StreetSuffix()}
        };

        private static readonly IEnumerable<Func<string>> s_streetAddressFormats = new Func<string>[]
        {
            () =>
            string.Format(CultureInfo.CurrentCulture,
                          Resources.Address.AddressFormat.Split(Config.SEPARATOR).Random().Trim(), StreetName())
        };

        #endregion
    }
}
