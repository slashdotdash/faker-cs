using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.en_US
{
    [TestFixture]
    [SetUICulture("en-US")]
    [SetCulture("en-US")]
    [Category("Culture 'en_US'")]
    public class AddressAmericanTests : AddressTestsBase
    {
        [Test]
        [Repeat(10000)]
        public override void Should_Get_City()
        {
            string city = Address.City();

            Assert.That(city, Is.StringMatching("^([A-Z]('[A-Z])?[a-z]+ ?){1,2}$"));
        }
    }
}