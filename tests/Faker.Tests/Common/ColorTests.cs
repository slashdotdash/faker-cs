using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class ColorTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Generate_Valid_Alpha_Channel()
        {
            var result = Color.AlphaChannel();

            Assert.That(result, Is.GreaterThanOrEqualTo(0.0).And.LessThanOrEqualTo(1.0));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Valid_Hex_Color()
        {
            var result = Color.HexColor();

            Assert.That(result, Is.StringMatching(@"^#[A-F0-9]{6}$"));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Valid_HSL_Values()
        {
            var result = Color.HSL();

            Assert.That(result, Has.Length.EqualTo(3).And.All.GreaterThanOrEqualTo(0.0).And.LessThanOrEqualTo(360.00));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Valid_HSLA_Values()
        {
            var result = Color.HSLA();

            Assert.That(result, Has.Length.EqualTo(4));
            for (var i = 0; i < 3; i++)
            {
                Assert.That(result[i], Is.GreaterThanOrEqualTo(0).And.LessThanOrEqualTo(360));
            }

            Assert.That(result[3], Is.GreaterThanOrEqualTo(0.0).And.LessThanOrEqualTo(1.0));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Valid_RGB_Values()
        {
            var result = Color.RGB();

            Assert.That(result, Has.Length.EqualTo(3).And.All.GreaterThanOrEqualTo(0).And.LessThan(256));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Valid_Single_HSL_Value()
        {
            var result = Color.SingleHSL();

            Assert.That(result, Is.GreaterThanOrEqualTo(0.0).And.LessThanOrEqualTo(360.00));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Valid_Single_RGB_Value()
        {
            var result = Color.SingleRGB();

            Assert.That(result, Is.GreaterThanOrEqualTo(0).And.LessThan(256));
        }
    }
}