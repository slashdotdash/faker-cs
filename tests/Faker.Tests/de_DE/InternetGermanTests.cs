using Faker.Tests.Common;
using NUnit.Framework;

namespace Faker.Tests.de_DE
{
    [TestFixture]
    [SetUICulture("de-DE")]
    [SetCulture("de-DE")]
    [Category("Culture 'de_DE'")]
    public class InternetGermanTests
    {
        [Test]
        [Repeat(1000)]
        public void Should_Create_Free_Email()
        {
            string freeEmailsFormat = Resources.Internet.FreeMail.ToFormat();

            string email = Internet.FreeEmail();

            Assert.That(email, Is.StringMatching(string.Format("@({0})$", freeEmailsFormat))
                                 .And.StringMatching(InternetTests.EMAIL_REGEX)
                                 .And.Not.Contains("www"));
        }
    }
}
