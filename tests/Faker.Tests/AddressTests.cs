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
            //string secondary = "("
            //                   + Resources.Address.SecondaryAddress.Replace(';', '|')
            //                              .Replace(".", @"\.")
            //                              .Replace("###", "[0-9]{3}") + ")";

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
    }
}
