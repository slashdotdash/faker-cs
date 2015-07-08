using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    [SetCulture("en-US")]
    public class NameTests
    {
        [Test]
        [Repeat(10000)]
        public void Should_Get_FullName()
        {
            string name = Name.FullName();
            //Assert.IsTrue(Regex.IsMatch(name, @"^(\w+\.? ?){2,3}$"));
            Assert.That(name, Is.StringMatching(@"^([\w']+\.? ?){2,4}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_FullName_With_Standard_Format()
        {
            string name = Name.FullName(NameFormats.Standard);
            //Assert.IsTrue(Regex.IsMatch(name, @"^\w+\.? \w+\.?$"));
            Assert.That(name, Is.StringMatching(@"^([\w']+\.? ?){2}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Prefix()
        {
            string prefix = Name.Prefix();
            //Assert.IsTrue(Regex.IsMatch(prefix, @"^[A-Z][a-z]+\.?$"));
            Assert.That(prefix, Is.StringMatching(@"^[A-Z][a-z]+\.?$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Suffix()
        {
            string suffix = Name.Suffix();
            //Assert.IsTrue(Regex.IsMatch(suffix, @"^[A-Z][A-Za-z]*\.?$"));
            Assert.That(suffix, Is.StringMatching(@"^[A-Z][A-z]*?\.?$"));
        }
    }
}
