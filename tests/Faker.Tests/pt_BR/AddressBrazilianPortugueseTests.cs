using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.pt_BR
{
    [TestFixture]
    [SetUICulture("pt-BR")]
    [SetCulture("pt-BR")]
    [Category("Culture 'pt_BR'")]
    public class AddressBrazilianPortugueseTests : AddressTestsBase
    {
        private const string ADDRESS_REGEX1 = @"^\d{3,5} (\w+ ){1,3}\w+";
        private const string ADDRESS_REGEX2 = @"^[\d]{3,5} \w'\w+ \w+";

        [Test]
        [Repeat(10000)]
        public override void Should_Get_City()
        {
            string city = Address.City();

            //Assert.That(city, Is.StringMatching("^(\\w+ ?){1,2}$")
            //                    .Or.StringMatching(@"^(\w'\w+ ?){1,2}"));

            Assert.That(city, Is.StringMatching(@"^(\w+ ?){2,5}$"));
        }

        [Test]
        [Repeat(10000)]
        public override void Should_Get_Street_Address()
        {
            string address = Address.StreetAddress();

            Assert.That(address,
                        Is.StringMatching(ADDRESS_REGEX1 + "$")
                          //.Or.StringMatching(ADDRESS_REGEX2 + "$")
                          );
        }

        [Test]
        [Repeat(10000)]
        public override void Should_Get_Street_Address_With_Secondary_Address()
        {
            string secondary = Resources.Address.SecondaryAddress.ToFormat(true);

            string address = Address.StreetAddress(true);

            Assert.That(address,
                        Is.StringMatching(ADDRESS_REGEX1 + " " + secondary + "$")
                          //.Or.StringMatching(ADDRESS_REGEX2 + " " + secondary + "$")
                          );
        }
    }
}
