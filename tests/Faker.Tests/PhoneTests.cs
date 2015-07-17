using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class PhoneTests
    {
        [TestCase("01## ### ####", @"^01[0-9]{2} [0-9]{3} [0-9]{4}$")]
        [TestCase("###-###-####", @"^([0-9]{3}-){2}[0-9]{4}$")]
        [TestCase("### ### ####", @"^([0-9]{3} ){2}[0-9]{4}$")]
        public void Should_Generate_Phone_Number_Based_On_Pattern(string pattern, string regexMatchPattern)
        {
            string number = Phone.Number(pattern);

            Assert.That(number, Is.StringMatching(regexMatchPattern));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Cell_Phone_Number()
        {
            string expectedFormat = "^("
                                    + Resources.Phone.CellPhoneFormats.Replace(';', '|')
                                               .Replace("#", "[0-9]")
                                               .Replace("(", @"\(")
                                               .Replace(")", @"\)")
                                               .Replace("+", "\\+") + ")$";

            string number = Phone.CellNumber();

            Assert.That(number, Is.StringMatching(expectedFormat));
        }

        [Test]
        public void Should_Generate_Extension()
        {
            string extension = Phone.Extension();

            Assert.That(extension, Has.Length.EqualTo(4).And.All.Not.NaN);
        }

        [Test]
        public void Should_Generate_Extensions_With_Specified_Length()
        {
            string extension = Phone.Extension(12);

            Assert.That(extension, Has.Length.EqualTo(12).And.All.Not.NaN);
        }

        [Test]
        [Repeat(10000)]
        [SetUICulture("nb-NO")]
        public void Should_Generate_Norwegian_Phone_Number()
        {
            string number = Phone.Number();

            Assert.That(number,
                        Is.StringMatching(@"^\+47( [0-9]{2}){4}$")
                          .Or.StringMatching(@"^[0-9]{3} [0-9]{2} [0-9]{3}$")
                          .Or.StringMatching(@"^([0-9]{2} ?){4}$"));
        }

        [Test]
        [Repeat(10000)]
        [SetUICulture("en")]
        public void Should_Generate_Phone_Number()
        {
            string number = Phone.Number();

            Assert.That(number, Is.StringMatching(@"^[0-9 x\-(\)\.]+$"));
        }

        [Test]
        public void Should_Generate_Subscriber_Number()
        {
            string subNumber = Phone.SubscriberNumber();

            Assert.That(subNumber, Has.Length.EqualTo(4).And.All.Not.NaN);
        }
    }
}
