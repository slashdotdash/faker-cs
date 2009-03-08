using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Faker.Tests
{
    [TestFixture]
    public class LoremFixture
    {
        [Test]
        public void Should_Return_Word_List()
        {
            var words = Lorem.Words(10);
            Assert.AreEqual(10, words.Count());
        }

        [Test]
        public void Should_Generate_Random_Word_Sentence()
        {
            var sentence = Lorem.Sentence();
            Assert.IsTrue(Regex.IsMatch(sentence, @"[A-Z][a-z ]+\."));
        }

        [Test]
        public void Should_Generate_Paragraph()
        {
            var para = Lorem.Paragraph();
            Assert.IsTrue(Regex.IsMatch(para, @"([A-Z][a-z ]+\.\s?){3,6}"));
        }
    }
}