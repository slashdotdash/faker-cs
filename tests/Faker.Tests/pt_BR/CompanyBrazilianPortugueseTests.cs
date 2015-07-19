using Faker.Tests.Base;
using NUnit.Framework;

namespace Faker.Tests.pt_BR
{
    [TestFixture]
    [SetUICulture("pt-BR")]
    [SetCulture("pt-BR")]
    [Category("Culture 'pt_BR'")]
    public class CompanyBrazilianPortugueseTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Generate_Bullshit()
        {
            string bs1Format = Resources.Company.BS1.ToFormat();
            string bs2Format = Resources.Company.BS2.ToFormat();
            string bs3Format = Resources.Company.BS3.ToFormat();

            string bs = Company.Bullshit();

            bs.AssertFormats(bs1Format.Combine(bs2Format, bs3Format));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Catchphrase()
        {
            string catch1Format = Resources.Company.Buzzwords1.ToFormat();
            string catch2Format = Resources.Company.Buzzwords2.ToFormat();
            string catch3Format = Resources.Company.Buzzwords3.ToFormat();

            string catchPhrase = Company.CatchPhrase();

            catchPhrase.AssertFormats(catch1Format.Combine(catch2Format, catch3Format));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Company_Name()
        {
            string lastNameFormat = Resources.Name.Last.ToFormat();
            string suffixCompanyFormat = Resources.Company.Suffix.ToFormat();

            string name = Company.Name();

            name.AssertFormats(
                               lastNameFormat.Combine(suffixCompanyFormat),
                               lastNameFormat + "-" + lastNameFormat,
                               (lastNameFormat + ",").Combine(lastNameFormat, "and", lastNameFormat));
        }
    }
}
