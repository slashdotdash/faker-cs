using NUnit.Framework;

namespace Faker.Tests.de_DE
{
    [TestFixture]
    [SetUICulture("de-DE")]
    [SetCulture("de-DE")]
    [Category("Culture 'de_DE'")]
    public class NameGermanTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Get_FullName()
        {
            string firstNameFormat = Resources.Name.First.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();
            string prefixNameFormat = Resources.Name.Prefix.ToFormat();
            string suffixNameFormat = Resources.Name.Suffix.ToFormat();

            string name = Name.FullName();

            name.AssertFormats(
                               firstNameFormat.Combine(lastNameFormat),
                               prefixNameFormat.Combine(firstNameFormat, lastNameFormat),
                               firstNameFormat.Combine(lastNameFormat, suffixNameFormat),
                               prefixNameFormat.Combine(firstNameFormat, lastNameFormat, suffixNameFormat));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Get_FullName_With_Standard_Format()
        {
            string firstNameFormat = Resources.Name.First.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();

            string name = Name.FullName(NameFormats.Standard);

            name.AssertFormats(firstNameFormat.Combine(lastNameFormat));
        }
    }
}
