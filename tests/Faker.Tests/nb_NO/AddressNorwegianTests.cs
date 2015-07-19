using Faker.Extensions;
using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.nb_NO
{
    [TestFixture]
    [SetUICulture("nb-NO")]
    [SetCulture("nb-NO")]
    [Category("Culture 'nb_NO'")]
    public class AddressNorwegianTests : AddressTestsBase
    {
        private const string ADDRESS_REGEX1 = @"^(\w+ ){1,2}\d{1,3}";
        private const string ADDRESS_REGEX2 = @"^\d{1,3} (\w+ ){1,2}";

        [Test]
        [Repeat(10000)]
        public override void Should_Get_Street_Address()
        {
            string address = Address.StreetAddress();

            Assert.That(address,
                        Is.StringMatching(ADDRESS_REGEX1 + "$")
                          .Or.StringMatching(ADDRESS_REGEX2 + "$"));
        }

        [Test]
        [Repeat(10000)]
        public override void Should_Get_Street_Address_With_Secondary_Address()
        {
            string secondary = Resources.Address.SecondaryAddress.ToFormat(true);

            string address = Address.StreetAddress(true);

            Assert.That(address,
                        Is.StringMatching(ADDRESS_REGEX1 + " " + secondary + "$")
                          .Or.StringMatching(ADDRESS_REGEX2 + secondary + "$"));
        }
    }
}
