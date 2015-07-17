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

            Assert.That(result.Distinct(), Is.EquivalentTo(input));
        }

        [Test]
        public void Should_Return_Single_Item_From_Array()
        {
            string s = new[] {"Foo"}.Random();

            Assert.That(s, Is.EqualTo("Foo"));
        }

        [Test]
        [TestCase("")]
        [TestCase("       ")]
        public void Should_Throw_ArgumentException_When_Random_Source_Is_Empty(string testString)
        {
            var ex = Assert.Throws<ArgumentException>(() => testString.Random());

            Assert.That(ex.Message, Is.StringStarting("The specified source can not be an empty string."));
            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void Should_Throw_ArgumentNullException_If_ResourceString_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ArrayExtensions.RandomResource(null));

            Assert.That(ex.ParamName, Is.EqualTo("resourceString"));
        }

        [Test]
        public void Should_Throw_ArgumentNullException_When_Random_Source_Is_Null()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ((string) null).Random());

            Assert.That(ex.ParamName, Is.EqualTo("source"));
        }

        [Test]
        public void Should_Throw_Exception_For_Empty_Array()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => new string[0].Random());
            Assert.That(ex.Message, Is.EqualTo("Array must contain at least one item"));
        }
    }
}
