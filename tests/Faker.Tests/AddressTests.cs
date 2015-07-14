using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    [SetCulture("en-US")]
    [SuppressMessage("ReSharper", "UseStringInterpolation")]
    public class AddressTests
    {
        private const string ADDRESS_REGEX1 = @"^[0-9]{3,5} [A-Z][A-z]+ [A-Z][a-z]+";
        private const string ADDRESS_REGEX2 = @"^[0-9]{3,5} [OD]'[A-Z][a-z]+ [A-Z][a-z]+";
        private const string ADDRESS_REGEX3 = @"^[0-9]{3,5} [A-Z][A-z]+";
        private const string ADDRESS_REGEX4 = @"^[0-9]{3,5} [OD]'[A-Z][a-z]+";

        [Test]
        [Repeat(10000)]
        public void Should_Get_Building_Number()
        {
            string buildingNum = Address.BuildingNumber();

            Assert.That(buildingNum, Has.Length.GreaterThanOrEqualTo(3)
                                        .Or.Length.LessThanOrEqualTo(5));
            Assert.That(buildingNum, Is.StringMatching("^[0-9]+$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_City()
        {
            string city = Address.City();

            Assert.That(city,
                        Is.StringMatching(@"^([A-Z]('[A-Z])?[a-z]+ ?){1,2}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_City_Prefix()
        {
            string[] existingPrefixies = Resources.Address.CityPrefix.Split(Config.SEPARATOR);

            string prefix = Address.CityPrefix();

            //Assert.That(prefix, Is.SubsetOf(existingPrefixies));
            Assert.That(new[] {prefix}, Is.SubsetOf(existingPrefixies));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_City_Suffix()
        {
            string[] existingSuffixes = Resources.Address.CitySuffix.Split(Config.SEPARATOR);
            string suffix = Address.CitySuffix();

            Assert.That(new[] {suffix}, Is.SubsetOf(existingSuffixes));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Country()
        {
            string[] existingCountries = Resources.Address.Country.Split(Config.SEPARATOR);

            string country = Address.Country();

            Assert.That(new[] {country}, Is.SubsetOf(existingCountries));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_Country_Code()
        {
            string[] existingCountryCodes = Resources.Address.CountryCode.Split(Config.SEPARATOR);

            string countryCode = Address.CountryCode();

            Assert.That(new[] {countryCode}, Is.SubsetOf(existingCountryCodes));
        }

        [Test]
        public void Should_Get_Default_Country()
        {
            string expectedCountry = Resources.Address.DefaultCountry;

            string actualCountry = Address.DefaultCountry();

            Assert.That(actualCountry, Is.EqualTo(expectedCountry));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Latitude()
        {
            double actual = Address.Latitude();

            Assert.That(actual, Is.GreaterThanOrEqualTo(-90)
                                  .And.LessThanOrEqualTo(90));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Longitude()
        {
            double actual = Address.Longitude();

            Assert.That(actual, Is.GreaterThanOrEqualTo(-180)
                                  .And.LessThanOrEqualTo(180));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_State()
        {
            string[] expectedStates = Resources.Address.State.Split(Config.SEPARATOR);

            string state = Address.State();

            Assert.That(new[] {state}, Is.SubsetOf(expectedStates));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_State_Abbreviation()
        {
            string[] possibleAbberivations = Resources.Address.StateAbbr.Split(Config.SEPARATOR);

            string stateAbbr = Address.StateAbbreviation();

            Assert.That(new[] {stateAbbr}, Is.SubsetOf(possibleAbberivations));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Street_Address()
        {
            string address = Address.StreetAddress();
            Assert.That(address,
                        Is.StringMatching(ADDRESS_REGEX1 + "$")
                          .Or.StringMatching(ADDRESS_REGEX2 + "$")
                          .Or.StringMatching(ADDRESS_REGEX3 + "$")
                          .Or.StringMatching(ADDRESS_REGEX4 + "$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Street_Address_With_Secondary_Address()
        {
            string secondary = string.Format("({0})", Resources.Address.SecondaryAddress)
                                     .Replace(';', '|')
                                     .Replace(".", "\\.")
                                     .Replace("#", "[0-9]");

            string address = Address.StreetAddress(true);
            //Assert.That(address, Is.StringMatching(@"^[0-9]{3,5} [A-Z][A-z' ]+ (Suite|Apt\.) [0-9]{3}$"));

            Assert.That(address,
                        Is.StringMatching(string.Format("{0} {1}$", ADDRESS_REGEX1, secondary))
                          .Or.StringMatching(string.Format("{0} {1}$", ADDRESS_REGEX2, secondary))
                          .Or.StringMatching(string.Format("{0} {1}$", ADDRESS_REGEX3, secondary))
                          .Or.StringMatching(string.Format("{0} {1}$", ADDRESS_REGEX4, secondary)));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_TimeZone()
        {
            string[] possibleResults = Resources.Address.TimeZone.Split(Config.SEPARATOR);

            string result = Address.TimeZone();

            Assert.That(new[] {result}, Is.SubsetOf(possibleResults));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Zip_Code()
        {
            string zipcodeRegex = "^(" + Resources.Address.ZipCode.Replace(';', '|').Replace("#", "[0-9]") + ")$";

            string zipcode = Address.ZipCode();

            Assert.That(zipcode, Is.StringMatching(zipcodeRegex));
        }
    }
}
