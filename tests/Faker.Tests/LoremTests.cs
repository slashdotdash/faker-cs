using System;
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
        public void Should_Generate_Multiple_Paragraphs([Range(3, 100)] int num)
        {
            IEnumerable<string> paragraphs = Lorem.Paragraphs(num);

            Assert.That(paragraphs.ToArray(), Is.Not.Null.And.Not.Empty.And.Length.EqualTo(num)
                                                .And.All.Not.Empty);
        }

        [Test]
        public void Should_Generate_Characters([Range(1, 100)] int charCount)
        {
            string characters = Lorem.Characters(charCount);

            Assert.That(characters, Has.Length.EqualTo(charCount));
        }

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

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Should_Throw_ArgumentOutOfRangeException_If_Sentence_Count_Below_Zero()
        {
            Lorem.Paragraph(-1);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Should_Throw_ArgumentOutOfRangeException_If_Sentences_Count_Below_Zero()
        {
            Lorem.Sentences(-1);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Should_Throw_ArgumentOutOfRangeException_If_Sentences_Count_Is_Zero()
        {
            Lorem.Sentences(0);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Should_Throw_ArgumentOutOfRangeException_If_Word_Count_Below_Zero()
        {
            Lorem.Sentence(-1);
        }

        [Test]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void Should_Throw_ArgumentOutOfRangeException_If_Words_Count_Below_Zero()
        {
            Lorem.Words(-1);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Should_Throw_ArgumentOutOfRangeException_If_Paragraphs_Count_Below_Zero()
        {
            Lorem.Paragraphs(-1);
        }
    }
}
