using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class AppTests
    {
        [Test]
        [Repeat(100)]
        public void Should_Generate_Author()
        {
            string author = App.Author();

            Assert.That(author,
                        Is.StringMatching(@"^([\w']+\.? ?){2,4}$")
                          .Or.StringMatching(@"^[\w']+ (and )?[\w]+$")
                          .Or.StringMatching(@"^[\w']+-[\w']+$")
                          .Or.StringMatching(@"^[\w']+, [\w']+ and [\w']+$"));
        }

        [Test]
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
            string versionFormat = Resources.App.VersionFormat.Replace(';', '|')
                                            .Replace(".", "\\.")
                                            .Replace("#", "[0-9]");

            string version = App.Version();

            Assert.That(version, Is.StringMatching("^(" + versionFormat + ")$"));
        }
    }
}
