using System;
using System.Collections.Generic;
using Faker.Extensions;

namespace Faker
{
    public static class Address
    {
        public static string Country()
        {
            return Resources.Address.Country.Split(Config.Separator).Random().Trim();
        }

        public static string ZipCode()
        {
            return Resources.Address.ZipCode.Split(Config.Separator).Random().Trim().Numerify();
        }

        public static string UsState()
        {

            return Resources.Address.UsState.Split(Config.Separator).Random().Trim();
        }

        public static string UsStateAbbr()
        {
            return Resources.Address.UsStateAbbr.Split(Config.Separator).Random();
        }
        
        public static string CityPrefix()
        {
            return Resources.Address.CityPrefix.Split(Config.Separator).Random();
        }

        public static string CitySufix()
        {
            return Resources.Address.CitySufix.Split(Config.Separator).Random();
        }

        public static string City()
        {
            return _cityFormats.Random();
        }

        public static string StreetSuffix()
        {
            return Resources.Address.StreetSuffix.Split(Config.Separator).Random();
        }

        public static string StreetName()
        {
            return String.Join(Resources.Address.StreetNameSeparator, _streetFormats.Random());
        }
        
        public static string StreetAddress()
        {
            return StreetAddress(false);
        }

        public static string StreetAddress(bool includeSecondary)
        {
            return _streetAddressFormats.Random().Trim().Numerify() + (includeSecondary ? " " + SecondaryAddress() : "");
        }

        public static string SecondaryAddress()
        {
            return Resources.Address.SecondaryAddress.Split(Config.Separator).Random().Trim().Numerify();
        }

        public static string UkCounty()
        {
            return Resources.Address.UkCounties.Split(Config.Separator).Random().Trim();
        }

        public static string UkCountry()
        {
            return Resources.Address.UkCountry.Split(Config.Separator).Random().Trim();
        }

        public static string UkPostCode()
        {
            return Resources.Address.UkPostCode.Split(Config.Separator).Random().Trim().Numerify().Letterify();
        }

        #region Format Mappings
        private static readonly IEnumerable<Func<string>> _cityFormats = new List<Func<string>>
        {
            () => string.Format("{0} {1}{2}", CityPrefix(), Name.First(), CitySufix()),
            () => string.Format("{0} {1}", CityPrefix(), Name.First()),
            () => string.Format("{0}{1}", Name.First(), CitySufix()),
            () => string.Format("{0}{1}", Name.Last(), CitySufix())
        };

        private static readonly IEnumerable<Func<string[]>> _streetFormats = new List<Func<string[]>>
        {
            () => new [] { Name.Last(), StreetSuffix() },
            () => new [] { Name.First(), StreetSuffix() }
        };

        private static readonly IEnumerable<Func<string>> _streetAddressFormats = new List<Func<string>>
        {
            () => string.Format(Resources.Address.AddressFormat.Split(Config.Separator).Random().Trim(), StreetName())
        };
        #endregion
    }
}