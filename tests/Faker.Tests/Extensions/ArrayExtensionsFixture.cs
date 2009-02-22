using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Faker.Extensions;
using NUnit.Framework;

namespace Faker.Tests.Extensions
{
    [TestFixture]
    public class ArrayExtensionsFixture
    {
        [Test]
        [ExpectedException(typeof(InvalidOperationException), "Array must contain at least one item")]
        public void Should_Throw_Exception_For_Empty_Array()
        {
            new string[] {}.Random();
        }

        [Test]
        public void Should_Return_Single_Item_From_Array()
        {
            var s = new [] { "Foo" }.Random();
            Assert.AreEqual("Foo", s);
        }
    }
}
