using System;
using System.Linq;
using Faker.Extensions;
using NUnit.Framework;

namespace Faker.Tests.Extensions
{
    [TestFixture]
    public class ArrayExtensionsFixture
    {
        [Test]
        public void Should_Throw_Exception_For_Empty_Array()
        {
            var exception = Assert.Throws<InvalidOperationException>(() => new string[] { }.Random());
            Assert.AreEqual("Array must contain at least one item", exception.Message);
        }

        [Test]
        public void Should_Return_Single_Item_From_Array()
        {
            var s = new [] { "Foo" }.Random();
            Assert.AreEqual("Foo", s);
        }

        [Test]
        public void Should_Return_All_Array_Items()
        {
            var input = new[] {"a", "b", "c"};
            var result = 100.Times(x => input.Random());
            
            Assert.AreEqual(3, result.Distinct().Count());
        }
    }
}
