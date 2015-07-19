using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class AddressTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Get_City_Prefix()
        {
            string[] existingPrefixies = Resources.Address.CityPrefix.Split(Config.SEPARATOR);

            string prefix = Address.CityPrefix();

            Assert.That(new[] {prefix}, Is.SubsetOf(existingPrefixies));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_City_Suffix()
        {
            string[] existingSuffixes = Resources.Address.CitySuffix.Split(Config.SEPARATOR);
            string suffix = Address.CitySuffix();

            Assert.That(new[] {suffix}, Is.SubsetOf(existingSuffixes));
        }

        [Test]
        [Repeat(1000)]
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
            string[] possibleCountries = Resources.Address.DefaultCountry.Split(Config.SEPARATOR);

            string actualCountry = Address.DefaultCountry();

            Assert.That(new[] {actualCountry}, Is.SubsetOf(possibleCountries));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_Latitude()
        {
            double actual = Address.Latitude();

            Assert.That(actual, Is.GreaterThanOrEqualTo(-90)
                                  .And.LessThanOrEqualTo(90));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_Longitude()
        {
            double actual = Address.Longitude();

            Assert.That(actual, Is.GreaterThanOrEqualTo(-180)
                                  .And.LessThanOrEqualTo(180));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_State()
        {
            string[] expectedStates = Resources.Address.State.Split(Config.SEPARATOR);

            string state = Address.State();

            Assert.That(new[] {state}, Is.SubsetOf(expectedStates));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_State_Abbreviation()
        {
            string[] possibleAbberivations = Resources.Address.StateAbbr.Split(Config.SEPARATOR);

            string stateAbbr = Address.StateAbbreviation();

            Assert.That(new[] {stateAbbr}, Is.SubsetOf(possibleAbberivations));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_TimeZone()
        {
            string[] possibleResults = Resources.Address.TimeZone.Split(Config.SEPARATOR);

            string result = Address.TimeZone();

            Assert.That(new[] {result}, Is.SubsetOf(possibleResults));
        }
    }
}
