using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class NameTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Get_Prefix()
        {
            string[] possiblePrefixes = Resources.Name.Prefix.Split(Config.SEPARATOR);

            string prefix = Name.Prefix();

            Assert.That(new[] {prefix}, Is.SubsetOf(possiblePrefixes));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_Suffix()
        {
            string[] possibleSuffixes = Resources.Name.Suffix.Split(Config.SEPARATOR);

            string suffix = Name.Suffix();

            Assert.That(new[] {suffix}, Is.SubsetOf(possibleSuffixes));
        }
    }
}
