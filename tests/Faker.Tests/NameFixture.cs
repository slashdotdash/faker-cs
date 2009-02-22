using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Faker.Tests
{
    [TestFixture]
    public class NameFixture
    {
        [Test]
        public void Should_Get_FullName()
        {
            var name = Name.FullName();
            Assert.IsTrue(Regex.IsMatch(name, @"^(\w+\.? ?){2,3}$"));
        }

        [Test]
        public void Should_Get_FullName_With_Standard_Format()
        {
            var name = Name.FullName(NameFormats.Standard);
            Assert.IsTrue(Regex.IsMatch(name, @"^\w+\.? \w+\.?$"));
        }

        [Test]
        public void Should_Get_Prefix()
        {
            var prefix = Name.Prefix();
            Assert.IsTrue(Regex.IsMatch(prefix, @"^[A-Z][a-z]+\.?$"));
        }

        [Test]
        public void Should_Get_Suffix()
        {
            var suffix = Name.Suffix();
            Assert.IsTrue(Regex.IsMatch(suffix, @"^[A-Z][A-Za-z]*\.?$"));
        }
    }
}