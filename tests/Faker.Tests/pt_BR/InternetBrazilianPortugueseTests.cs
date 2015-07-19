using Faker.Tests.Common;
using NUnit.Framework;

namespace Faker.Tests.pt_BR
{
    [TestFixture]
    [SetUICulture("pt-BR")]
    [SetCulture("pt-BR")]
    [Category("Culture 'pt_BR'")]
    public class InternetBrazilianPortugueseTests
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
