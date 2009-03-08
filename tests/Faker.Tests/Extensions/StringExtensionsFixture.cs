using System.Linq;
using Faker.Extensions;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Faker.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsFixture
    {
        [Test]
        public void Should_Replace_Hash_Char_With_Random_Number()
        {
            var number = "#".Numerify();
            Assert.IsTrue(Regex.IsMatch(number, "^[0-9]$"));
            Assert.AreEqual(1, number.Length);
        }

        [Test]
        public void Should_Replace_Multiple_Hash_Chars_With_Different_Random_Numbers()
        {
            var number = "##########".Numerify();
            Assert.IsTrue(Regex.IsMatch(number, "^[0-9]+$"));
            Assert.IsTrue(number.Distinct().Count() > 1);
            Assert.AreEqual(10, number.Length);
        }

        [Test]
        public void Should_Replace_Question_Mark_With_Random_Letter()
        {
            var word = "?".Letterify();
            Assert.IsTrue(Regex.IsMatch(word, "^[a-z]$"));
            Assert.AreEqual(1, word.Length);
        }

        [Test]
        public void Should_Replace_Multiple_Question_Marks_With_Different_Random_Letters()
        {
            var word = "??????????".Letterify();
            Assert.IsTrue(Regex.IsMatch(word, "^[a-z]+$"));
            Assert.IsTrue(word.Distinct().Count() > 1);
            Assert.AreEqual(10, word.Length);
        }

        [Test]
        public void Should_Replace_Both_Hash_And_Question_Marks()
        {
            var word = "#?#?".Letterify().Numerify();
            Assert.IsTrue(Regex.IsMatch(word, "^[0-9][a-z][0-9][a-z]$"));
            Assert.AreEqual(4, word.Length);
        }

        [Test]
        public void Should_Capitalise_First_Lowercase_Letter()
        {
            Assert.AreEqual("The quick brown fox", "the quick brown fox".Capitalise());
        }
    }
}
