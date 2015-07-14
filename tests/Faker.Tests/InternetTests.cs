using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    [SuppressMessage("ReSharper", "UseStringInterpolation")]
    public class InternetTests
    {
        private const string EMAIL_REGEX =
            "^((([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+(\\.([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\/=\\?\\^_`{\\|}~]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])+)*)|((\\x22)((((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(([\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x7f]|\\x21|[\\x23-\\x5b]|[\\x5d-\\x7e]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(\\\\([\\x01-\\x09\\x0b\\x0c\\x0d-\\x7f]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF]))))*(((\\x20|\\x09)*(\\x0d\\x0a))?(\\x20|\\x09)+)?(\\x22)))@((([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.)+(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.?$";

        [Test]
        [Repeat(10000)]
        public void Should_Create_Email_Address()
        {
            string email = Internet.Email();
            //Assert.IsTrue(Regex.IsMatch(email, @".+@.+\.\w+"));
            Assert.That(email, Is.StringMatching(EMAIL_REGEX));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Create_Email_Address_From_Given_Name()
        {
            string email = Internet.Email("Bob Smith");
            //Assert.IsTrue(Regex.IsMatch(email, @"bob[_\.]smith@.+\.\w+"));
            Assert.That(email, Is.StringMatching(@"^bob[_\.]smith@")
                                 .And.StringMatching(EMAIL_REGEX));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Create_Free_Email()
        {
            string email = Internet.FreeEmail();
            //Assert.IsTrue(Regex.IsMatch(email, @".+@(gmail|hotmail|yahoo)\.com"));
            string freeMails = Resources.Internet.FreeMail.Replace(';', '|').Replace(".", "\\.");

            Assert.That(email, Is.StringMatching(string.Format("@({0})$", freeMails))
                                 .And.StringMatching(EMAIL_REGEX));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Create_User_Name()
        {
            string username = Internet.UserName();
            //Assert.IsTrue(Regex.IsMatch(username, @"[a-z]+((_|\.)[a-z]+)?"));
            Assert.That(username, Is.StringMatching(@"^[a-z]+((_|\.)[a-z]+)?$"));
        }

        [Test]
        public void Should_Create_User_Name_From_Given_Name()
        {
            string username = Internet.UserName("Bob Smith");
            //Assert.IsTrue(Regex.IsMatch(username, @"bob[_\.]smith"));
            Assert.That(username, Is.StringMatching(@"^bob[_\.]smith$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_A_Random_Url()
        {
            string url = Internet.Url();

            Assert.That(url, Is.StringMatching(
                                               @"https?\:\/\/\w+(\.\w+){1,2}\/[a-z]+((_|\.)[a-z]+)?$")
                               .Or.StringMatching(
                                                  @"https?\:\/\/www2?\.\w+(\.\w+){1,2}\/[a-z]+((_|\.)[a-z]+)?$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Domain_Name()
        {
            string domain = Internet.DomainName();
            //Assert.IsTrue(Regex.IsMatch(domain, @"\w+\.\w+"));
            Assert.That(domain, Is.StringMatching(@"^\w+(\.\w+){1,2}$")
                                  .Or.StringMatching(@"^www2?\.\w+(\.\w+){1,2}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Domain_Suffix()
        {
            string suffix = Internet.DomainSuffix();
            //Assert.IsTrue(Regex.IsMatch(suffix, @"^\w+(\.\w+)?"));
            Assert.That(suffix, Is.StringMatching(@"^\w+(\.\w+)?$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_Domain_Word()
        {
            string word = Internet.DomainWord();
            //Assert.IsTrue(Regex.IsMatch(word, @"^\w+$"));
            Assert.That(word, Is.StringMatching(@"^\w+$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_IP_Version_4_Address()
        {
            string ipAddressString = Internet.IPv4Address();

            IPAddress ipAddress = IPAddress.Parse(ipAddressString);

            Assert.That(ipAddress.AddressFamily, Is.EqualTo(AddressFamily.InterNetwork));

            //Assert.That(ipAddress, Is.StringMatching(@"^(\d{1,3}\.){3}\d{1,3}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Get_IP_Version_6_Address()
        {
            string ipAddressString = Internet.IPv6Address();

            IPAddress ipAddress = IPAddress.Parse(ipAddressString);

            Assert.That(ipAddress.AddressFamily, Is.EqualTo(AddressFamily.InterNetworkV6));

            //Assert.That(ipAddress, Is.StringMatching(@"^(\d{1,3}\.){3}\d{1,3}$"));
        }
    }
}
