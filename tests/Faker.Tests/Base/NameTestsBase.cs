using NUnit.Framework;

namespace Faker.Tests.Base
{
    public abstract class NameTestsBase
    {
        [Test]
        [Repeat(10000)]
        public virtual void Should_Get_FullName()
        {
            string name = Name.FullName();

            Assert.That(name, Is.StringMatching(@"^([\w\[\]']+\.? ?){2,7}"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_FullName_With_Standard_Format()
        {
            string name = Name.FullName(NameFormats.Standard);

            Assert.That(name, Is.StringMatching(@"^([\w']+\.? ?){2}$")
                .Or.StringMatching(@"^([\w\[\]]+\.? ?){4}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Prefix()
        {
            string[] possiblePrefixes = Resources.Name.Prefix.Split(Config.SEPARATOR);

            string prefix = Name.Prefix();

            Assert.That(new[] { prefix }, Is.SubsetOf(possiblePrefixes));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Suffix()
        {
            string[] possibleSuffixes = Resources.Name.Suffix.Split(Config.SEPARATOR);

            string suffix = Name.Suffix();

            Assert.That(new[] { suffix }, Is.SubsetOf(possibleSuffixes));
        }
    }
}