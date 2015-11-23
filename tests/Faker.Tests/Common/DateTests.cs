using System;
using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class DateTests
    {
        [SetUp]
        public void Setup()
        {
            numOfDays = 0;
        }

        private static int numOfDays;

        [Test]
        [Repeat(1000)]
        public void Should_Generate_Birthday_Between_Ages()
        {
            var maxDate = DateTime.Today.AddYears(-18);
            var minDate = DateTime.Today.AddYears(-66);
            var result = Date.Birthday(18, 66);

            Assert.That(result, Is.GreaterThanOrEqualTo(minDate).And.LessThanOrEqualTo(maxDate));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_DateTime_Between_Specified_Values()
        {
            var maxDate = DateTime.Now.AddDays(-50);
            var minDate = maxDate.AddYears(-3);

            var result = Date.Between(minDate, maxDate);

            Assert.That(result, Is.GreaterThanOrEqualTo(minDate).And.LessThanOrEqualTo(maxDate));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_DateTime_Between_Today_And_Number_Of_Future_Days()
        {
            numOfDays++;
            var minDate = DateTime.Today;
            var maxDate = minDate.AddDays(numOfDays);

            var result = Date.Forward(numOfDays);

            Assert.That(result, Is.GreaterThanOrEqualTo(minDate).And.LessThanOrEqualTo(maxDate));
        }

        [Test]
        [Repeat(1000)]
        public void Should_Generate_DateTime_Between_Today_And_Number_Of_Previous_Days()
        {
            numOfDays++;
            var maxDate = DateTime.Today;
            var minDate = maxDate.AddDays(-numOfDays);

            var result = Date.Backwards(numOfDays);

            Assert.That(result, Is.GreaterThanOrEqualTo(minDate).And.LessThanOrEqualTo(maxDate));
        }
    }
}