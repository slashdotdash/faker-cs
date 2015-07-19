using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    //[SetUICulture("en")]
    //[SetUICulture("en-US")]
    //[SetUICulture("nb-NO")]
    //[SetUICulture("de-DE")]
    [SetUICulture("pt-BR")]
    public class PhoneTests
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
        public void Should_Generate_Subscriber_Number()
        {
            string subNumber = Phone.SubscriberNumber();

            Assert.That(subNumber, Has.Length.EqualTo(4).And.All.Not.NaN);
        }
    }
}
