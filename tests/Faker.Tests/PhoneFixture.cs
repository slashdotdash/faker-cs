using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Faker.Tests
{
    [TestFixture]
    public class PhoneFixture
    {
        [Test]
        public void Should_Generate_Phone_Number()
        {
            var number = Phone.Number();
            Assert.IsTrue(Regex.IsMatch(number, @"[0-9 x\-\(\)\.]+"));
        }

        [TestCase("01## ### ####", @"01[0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]")]
        [TestCase("###-###-####", @"[0-9][0-9][0-9]\-[0-9][0-9][0-9]\-[0-9][0-9][0-9][0-9]")]
        [TestCase("### ### ####", @"[0-9][0-9][0-9]\s[0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9]")]
        public void Should_Generate_Phone_Number_Based_On_Pattern(string pattern, string regexMatchPattern)
        {
            var number = Phone.Number(pattern);
            Assert.IsTrue(Regex.IsMatch(number, regexMatchPattern));
        }
    }
}