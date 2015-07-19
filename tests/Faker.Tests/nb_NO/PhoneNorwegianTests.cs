using NUnit.Framework;

namespace Faker.Tests.nb_NO
{
    [TestFixture]
    [SetUICulture("nb-NO")]
    [SetCulture("nb-NO")]
    [Category("Culture 'nb_NO'")]
    public class PhoneNorwegianTests
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
