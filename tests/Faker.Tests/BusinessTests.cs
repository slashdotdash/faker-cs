using System;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class BusinessTests
    {
        [Test]
        public void Should_Generate_Credit_Card_Number()
        {
            string[] possibleNumbers = Resources.Business.CreditCardNumbers.Split(Config.SEPARATOR);

            string number = Business.CreditCardNumber();

            Assert.That(new[] {number}, Is.SubsetOf(possibleNumbers));
        }

        [Test]
        public void Should_Generate_Credit_Card_Type()
        {
            string[] possibleTypes = Resources.Business.CreditCardTypes.Split(Config.SEPARATOR);

            string actual = Business.CreditCardType();

            Assert.That(new[] {actual}, Is.SubsetOf(possibleTypes));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Credit_Expiry_Date()
        {
            DateTime minimumExpected = DateTime.Now.AddDays(365);

            DateTime actual = Business.CreditCardExpiryDate();
            DateTime maximumExpected = DateTime.Now.AddDays(365*5);

            Assert.That(actual, Is.GreaterThanOrEqualTo(minimumExpected)
                                  .And.LessThanOrEqualTo(maximumExpected));
        }
    }
}
