using NUnit.Framework;

namespace Faker.Tests.de_DE
{
    [TestFixture]
    [SetUICulture("de-DE")]
    [SetCulture("de-DE")]
    [Category("Culture 'de_DE'")]
    public class AppGermanTests
    {
        [Test]
        [Repeat(1000)]
        public virtual void Should_Generate_Author()
        {
            string firstNameFormat = Resources.Name.First.ToFormat();
            string lastNameFormat = Resources.Name.Last.ToFormat();
            string prefixNameFormat = Resources.Name.Prefix.ToFormat();
            string suffixNameFormat = Resources.Name.Suffix.ToFormat();
            string suffixCompanyFormat = Resources.Company.Suffix.ToFormat();

            string author = App.Author();

            author.AssertFormats(firstNameFormat.Combine(lastNameFormat),
                                 prefixNameFormat.Combine(firstNameFormat, lastNameFormat),
                                 firstNameFormat.Combine(lastNameFormat, suffixNameFormat),
                                 prefixNameFormat.Combine(firstNameFormat, lastNameFormat, suffixNameFormat),
                                 lastNameFormat.Combine(suffixCompanyFormat),
                                 lastNameFormat + "-" + lastNameFormat,
                                 (lastNameFormat + ",").Combine(lastNameFormat, "and", lastNameFormat));
        }
    }
}
