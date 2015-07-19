using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.pt_BR
{
    [TestFixture]
    [SetUICulture("pt-BR")]
    [SetCulture("pt-BR")]
    [Category("Culture 'pt_BR'")]
    public class AppBrazilianPortugueseTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Generate_Author()
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