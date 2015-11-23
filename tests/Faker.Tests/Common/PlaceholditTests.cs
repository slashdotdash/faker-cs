using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class PlaceholditTests
    {
        [Test]
        public void Should_Generate_Placeholdit_Uri_With_Custom_Background_Color()
        {
            const string expected = "https://placehold.it/300x300/ffffff.png";

            var actual = Placeholder.Placeholdit(backgroundColor: "ffffff");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_Generate_Placeholdit_Uri_With_Custom_Size()
        {
            const string expected = "https://placehold.it/250x150.png";

            var actual = Placeholder.Placeholdit("250x150");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_Generate_Placeholdit_Uri_With_Custom_Text()
        {
            const string expected = "https://placehold.it/300x300.png?text=My Custom Text";

            var actual = Placeholder.Placeholdit(text: "My Custom Text");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_Generate_Placeholdit_Uri_With_Custom_Text_Color()
        {
            const string expected = "https://placehold.it/300x300/D3D3D3/000.png";

            var actual = Placeholder.Placeholdit(textColor: "000");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_GeneratePlaceholdit_Uri_With_Custom_Format()
        {
            const string expected = "https://placehold.it/300x300.gif";

            var actual = Placeholder.Placeholdit(format: PlaceholditImageFormat.gif);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_GeneratePlaceholdit_Uri_With_Default_Values()
        {
            const string expected = "https://placehold.it/300x300.png";

            var actual = Placeholder.Placeholdit();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}