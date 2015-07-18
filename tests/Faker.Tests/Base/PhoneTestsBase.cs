using NUnit.Framework;

namespace Faker.Tests.Base
{
    public abstract class PhoneTestsBase
    {
        [TestCase("01## ### ####", @"^01\d{2} \d{3} \d{4}$")]
        [TestCase("###-###-####", @"^(\d{3}-){2}\d{4}$")]
        [TestCase("### ### ####", @"^(\d{3} ){2}\d{4}$")]
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
                                               .Replace("#", "\\d")
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
        [SetUICulture("en")]
        public virtual void Should_Generate_Phone_Number()
        {
            string number = Phone.Number();

            Assert.That(number, Is.StringMatching(@"^[\d x\-(\)\.]+$"));
        }

        [Test]
        public void Should_Generate_Subscriber_Number()
        {
            string subNumber = Phone.SubscriberNumber();

            Assert.That(subNumber, Has.Length.EqualTo(4).And.All.Not.NaN);
        }
    }
}
