using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;
using NUnit.Framework;

namespace Faker.Tests.Extensions
{  
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void Should_Invoke_Func_Given_Number_Of_Times()
        {
            var numbers = 10.Times(x => x).ToList();
            //Assert.AreEqual(10, numbers.Count());
            Assert.That(numbers, Has.Count.EqualTo(10));
        }

        [Test]
        public void Should_Throw_InvalidOperationException_if_No_Items()
        {
            Assert.Throws<InvalidOperationException>(()
                                                     => new List<Func<string>>().Random());
        }
    }
}
