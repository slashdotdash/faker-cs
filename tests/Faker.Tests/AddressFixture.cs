using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class AddressFixture
    {
        [Test]
        public void Should_Get_Street_Address()
        {
            var address = Address.StreetAddress();
            Assert.IsTrue(Regex.IsMatch(address, "^[0-9]{3,5} [A-Z][a-z]+ [A-Z][a-z]+$"));
        }

        [Test]
        public void Should_Get_Street_Address_With_Secondary_Address()
        {
            var address = Address.StreetAddress(true);
            Assert.IsTrue(Regex.IsMatch(address, @"^[0-9]{3,5} [A-Z][a-z]+ [A-Z][a-z]+ [A-Z][a-z]+\.? [0-9]{3}$"));
        }
    }
}
