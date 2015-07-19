using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Faker.Tests.Common
{
    [TestFixture]
    public class LoremTests
    {
        [Test]
        public void Should_Generate_Characters([Range(1, 100)] int charCount)
        {
            string characters = Lorem.Characters(charCount);

            Assert.That(characters, Has.Length.EqualTo(charCount));
        }

        [Test]
        public void Should_Generate_Multiple_Paragraphs([Range(3, 100)] int num)
        {
            IEnumerable<string> paragraphs = Lorem.Paragraphs(num);

            Assert.That(paragraphs.ToArray(), Is.Not.Null.And.Not.Empty.And.Length.EqualTo(num)
                                                .And.All.Not.Empty);
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Paragraph()
        {
            string para = Lorem.Paragraph();

            Assert.That(para, Is.StringMatching(@"^([A-z ]+\.\s?){3,6}$"));
        }

        [Test]
        [Repeat(10000)]
        public void Should_Generate_Random_Word_Sentence()
        {
            string sentence = Lorem.Sentence();

            Assert.That(sentence, Is.StringMatching(@"^[A-z ]+\.$"));
        }

        [Test]
        public void Should_Return_Word_List([Range(10, 100)] int length)
        {
            string possibleWords = Resources.Lorem.Words.ToFormat();

            IEnumerable<string> words = Lorem.Words(length);

            Assert.That(words.Count(), Is.EqualTo(length));
            Assert.That(words, Is.All.StringMatching("^" + possibleWords + "$"));
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_If_Characters_Count_Below_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Lorem.Characters(-1));
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_If_Paragraphs_Count_Below_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Lorem.Paragraphs(-1));
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_If_Sentence_Count_Below_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Lorem.Paragraph(-1));
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_If_Sentences_Count_Below_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Lorem.Sentences(-1));
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_If_Sentences_Count_Is_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Lorem.Sentences(0));
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_If_Word_Count_Below_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Lorem.Sentence(-1));
        }

        [Test]
        public void Should_Throw_ArgumentOutOfRangeException_If_Words_Count_Below_Zero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Lorem.Words(-1));
        }
    }
}
