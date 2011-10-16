using System.Text.RegularExpressions;
using NUnit.Framework;

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

        [Test]
        public void Should_Generate_Phone_Number_DE()
        {
            var number = Phone.Number(Languages.de_DE);
            Assert.IsTrue(Regex.IsMatch(number, @"[0-9 x\-\(\)\.]+"));
        }
    }
}