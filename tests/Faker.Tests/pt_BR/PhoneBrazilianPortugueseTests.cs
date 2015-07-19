using NUnit.Framework;

namespace Faker.Tests.pt_BR
{
    [TestFixture]
    [SetUICulture("pt-BR")]
    [SetCulture("pt-BR")]
    [Category("Culture 'pt_BR'")]
    public class PhoneBrazilianPortugueseTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Generate_Cell_Phone_Number()
        {
            string expectedFormat = Resources.Phone.CellPhoneFormats.ToFormat();

            string number = Phone.CellNumber();

            number.AssertFormats(expectedFormat);
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Phone_Number()
        {
            string expectedFormat = Resources.Phone.Formats.ToFormat();

            string number = Phone.Number();

            number.AssertFormats(expectedFormat);
        }
    }
}
