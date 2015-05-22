using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class EnumerationFixture
    {
        [TestFixtureSetUp]
        public void Setup()
        {
            Thread.CurrentThread.CurrentCulture   = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
        }

        enum Sizes
        {
            Small,
            Medium,
            Large
        }

        [Test]
        public void Should_Get_Random_Enum()
        {
            var size = Enumeration.Random<Sizes>();
            Assert.IsTrue(size.GetType() == typeof(Sizes));
        }

        

    }
}
