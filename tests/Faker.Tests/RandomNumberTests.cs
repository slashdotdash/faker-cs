using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class RandomNumberTests
    {
        [Test]
        [Repeat(10000)]
        public void Should_Generate_Number_Between_50_And_100()
        {
            int num = RandomNumber.Next(50, 100);

            Assert.That(num, Is.GreaterThanOrEqualTo(50)
                               .And.LessThan(100));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Number_Obove_Zero()
        {
            int num = RandomNumber.Next();

            Assert.That(num, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_NumberBetween_Zero_And_1000()
        {
            int num = RandomNumber.Next(1000);

            Assert.That(num, Is.GreaterThanOrEqualTo(0)
                               .And.LessThan(1000));
        }
    }
}
