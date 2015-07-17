using System.Linq;
using Faker.Extensions;
using NUnit.Framework;

namespace Faker.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void Should_Capitalise_First_Lowercase_Letter()
        {
            const string expected = "The quick brown fox";
            string actual = "the quick brown fox".Capitalise();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Should_Not_Replace_Characters_If_ReplaceVariables_Is_False()
        {
            const string expected = "{Name.First}";

            string actual = expected.Transform(false);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Replace_Both_Hash_And_Question_Marks()
        {
            string word = "#?#?".Letterify().Numerify();

            Assert.That(word, Has.Length.EqualTo(4)
                                 .And.StringMatching(@"^([0-9][a-z]){2}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Replace_Hash_Char_With_Random_Number()
        {
            string number = "#".Numerify();

            Assert.That(number, Has.Length.EqualTo(1)
                                   .And.StringMatching(@"^[0-9]$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Replace_Multiple_Hash_Chars_With_Different_Random_Numbers()
        {
            string number = "##########".Numerify();

            Assert.That(number, Has.Length.EqualTo(10));
            Assert.That(number.Distinct().ToArray(), Has.Length.GreaterThan(1));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Replace_Multiple_Question_Marks_With_Different_Random_Letters()
        {
            string word = "??????????".Letterify();

            Assert.That(word, Has.Length.EqualTo(10)
                                 .And.StringMatching("^[a-z]+$"));
            Assert.That(word.Distinct().ToArray(), Has.Length.GreaterThan(1));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Replace_Question_Mark_With_Random_Letter()
        {
            string word = "?".Letterify();

            Assert.That(word, Has.Length.EqualTo(1)
                                 .And.StringMatching(@"^[a-z]$"));
        }
    }
}
