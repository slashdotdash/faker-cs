using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class AppTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Generate_Name()
        {
            string[] possibleNames = Resources.App.Name.Split(Config.SEPARATOR);

            string name = App.Name();

            Assert.That(new[] {name}, Is.SubsetOf(possibleNames));
        }

        [Test]
        [Repeat(100)]
        public void Should_Generate_Version()
        {
            string versionFormat = Resources.App.VersionFormat.ToFormat();

            string version = App.Version();

            version.AssertFormats(versionFormat);
        }
    }
}
