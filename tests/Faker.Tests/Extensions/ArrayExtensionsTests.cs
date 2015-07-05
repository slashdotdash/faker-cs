using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;
using NUnit.Framework;

namespace Faker.Tests.Extensions
{
    [TestFixture]
    public class ArrayExtensionsTests
    {
        [Test]
        public void Should_Return_All_Array_Items()
        {
            var input = new[] {"a", "b", "c"};
            IEnumerable<string> result = 100.Times(x => input.Random());

            //Assert.AreEqual(3, result.Distinct().Count());
            Assert.That(result.Distinct(), Is.EquivalentTo(input));
        }

        [Test]
        public void Should_Return_Single_Item_From_Array()
        {
            string s = new[] {"Foo"}.Random();
            //Assert.AreEqual("Foo", s);
            Assert.That(s, Is.EqualTo("Foo"));
        }

        [Test]
        [ExpectedException(typeof (InvalidOperationException), ExpectedMessage = "Array must contain at least one item")
        ]
        public void Should_Throw_Exception_For_Empty_Array()
        {
            //var exception = Assert.Throws<InvalidOperationException>(() => new string[] { }.Random());
            //Assert.AreEqual("Array must contain at least one item", exception.Message);
            new string[0].Random();
        }
    }
}
