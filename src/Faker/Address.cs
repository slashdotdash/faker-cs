using System;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of address related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="true" />
    public static class Address
    {
        /// <summary>
        ///     Gets a random building number.
        /// </summary>
        /// <returns>The building number.</returns>
        public static string BuildingNumber()
        {
            return Resources.Address.BuildingNumber.RandomResource().Numerify();
        }

        #region Random Example

        /// <summary>
        ///     Gets a random city.
        /// </summary>
        /// <returns>The random city.</returns>
        public static string City()
        {
            return Resources.Address.CityFormat.RandomResource().Transform(true);
        }

        #endregion

        /// <summary>
        ///     Gets a random city prefix.
        /// </summary>
        /// <returns>The random city prefix.</returns>
        public static string CityPrefix()
        {
            return Resources.Address.CityPrefix.RandomResource();
        }

        /// <summary>
        ///     Gets a random city suffix.
        /// </summary>
        /// <returns>The city suffix.</returns>
        public static string CitySuffix()
        {
            return Resources.Address.CitySuffix.RandomResource();
        }

        /// <summary>
        ///     Gets a random country.
        /// </summary>
        /// <returns>The random country.</returns>
        public static string Country()
        {
            return Resources.Address.Country.RandomResource();
        }

        /// <summary>
        ///     Gets a random country code.
        /// </summary>
        /// <returns>The random country code.</returns>
        public static string CountryCode()
        {
            return Resources.Address.CountryCode.RandomResource();
        }

        /// <summary>
        ///     Gets the default country.
        /// </summary>
        /// <returns>The default country.</returns>
        public static string DefaultCountry()
        {
            return Resources.Address.DefaultCountry;
        }

        /// <summary>
        ///     Gets a random latitude coordinate.
        /// </summary>
        /// <returns>The latitude.</returns>
        public static double Latitude()
        {
            return ((RandomNumber.NextDouble()*180) - 90);
        }

        /// <summary>
        ///     Gets a random longitude coordinate.
        /// </summary>
        /// <returns>The longitude.</returns>
        public static double Longitude()
        {
            return ((RandomNumber.NextDouble()*360) - 180);
        }

        /// <summary>
        ///     Gets a random secondary address.
        /// </summary>
        /// <returns>A random secondary address.</returns>
        public static string SecondaryAddress()
        {
            return Resources.Address.SecondaryAddress.RandomResource().Numerify();
        }

        /// <summary>
        ///     Gets a random state.
        /// </summary>
        /// <returns>The random state.</returns>
        public static string State()
        {
            return Resources.Address.State.RandomResource();
        }

        /// <summary>
        ///     Gets a random state abbreviation.
        /// </summary>
        /// <returns>The state abbreviation.</returns>
        public static string StateAbbreviation()
        {
            return Resources.Address.StateAbbr.RandomResource();
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
            return includeSecondaryAddress
                       ? Resources.Address.StreetAddressSecondaryFormat.RandomResource().Transform(true)
                       : Resources.Address.StreetAddressFormat.RandomResource().Transform(true);
        }

        /// <summary>
        ///     Gets the name of a random street.
        /// </summary>
        /// <returns>The name of a random street.</returns>
        public static string StreetName()
        {
            return Resources.Address.StreetNameFormat.RandomResource().Transform(true);
        }

        /// <summary>
        ///     Gets a random street suffix.
        /// </summary>
        /// <returns>The random street suffix.</returns>
        public static string StreetSuffix()
        {
            return Resources.Address.StreetSuffix.RandomResource();
        }

        /// <summary>
        ///     Gets a random time zone.
        /// </summary>
        /// <returns>The time zone.</returns>
        public static string TimeZone()
        {
            return Resources.Address.TimeZone.RandomResource();
        }

        /// <summary>
        ///     Gets a random zip code.
        /// </summary>
        /// <returns>The random zip code.</returns>
        public static string ZipCode()
        {
            return Resources.Address.ZipCode.RandomResource().Numerify();
        }
    }
}
