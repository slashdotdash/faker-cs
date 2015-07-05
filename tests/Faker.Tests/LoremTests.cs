using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    [SetCulture("en-US")]
    public class LoremTests
    {
        [Test]
        [Repeat(10000)]
        public void Should_Generate_Paragraph()
        {
            string para = Lorem.Paragraph();
            //Assert.IsTrue(Regex.IsMatch(para, @"([A-Z][a-z ]+\.\s?){3,6}"));
            Assert.That(para, Is.StringMatching(@"^([A-z ]+\.\s?){3,6}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Random_Word_Sentence()
        {
            string sentence = Lorem.Sentence();
            //Assert.IsTrue(Regex.IsMatch(sentence, @"[A-Z][a-z ]+\."));
            Assert.That(sentence, Is.StringMatching(@"^[A-z ]+\.$"));
        }

        [Test]
        public void Should_Return_Word_List([Range(10, 100)] int length)
        {
            //IEnumerable<string> words = Lorem.Words(10);
            //Assert.AreEqual(10, words.Count());
            IEnumerable<string> words = Lorem.Words(length);

            Assert.That(words.Count(), Is.EqualTo(length));
            Assert.That(words, Is.All.StringMatching(@"^[A-z]+$"));
        }
    }
}
