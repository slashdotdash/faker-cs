using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class CompanyTests
    {
        [Test]
        [Repeat(10)]
        public void Should_Generate_Logo_Url()
        {
            string url = Company.Logo();

            Assert.That(url, Is.StringStarting("http://pigment.github.io/fake-logos/logos/medium/color/")
                               .And.StringMatching(@"[0-9]+\.png$"));
        }
    }
}
