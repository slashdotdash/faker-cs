using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Extensions;

namespace Faker
{
    public static class Lorem
    {
        /// <summary>
        /// Get a random collection of words.
        /// </summary>
        /// <param name="count">Number of words required</param>
        /// <returns></returns>
        public static IEnumerable<string> Words(int count)
        {
            if (count <= 0) throw new ArgumentException("Count must be greater than zero", "count");

            return count.Times(x => Resources.Lorem.Words.Split(Config.Separator).Random());
        }

        /// <summary>
        /// Get the first word of the random word collection. Useful for unit tests.
        /// </summary>
        /// <returns></returns>
        public static string GetFirstWord()
        {
            return Resources.Lorem.Words.Split(Config.Separator).First();
        }

        /// <summary>
        /// Generates a capitalised sentence of random words.
        /// </summary>
        /// <param name="minWordCount">Minimum number of words required</param>
        /// <returns></returns>
        public static string Sentence(int minWordCount)
        {
            if (minWordCount <= 0) throw new ArgumentException("Count must be greater than zero", "minWordCount");

            return string.Join(" ", Words(minWordCount + RandomNumber.Next(6)).ToArray()).Capitalise() + ".";
        }

        public static string Sentence()
        {
            return Sentence(4);
        }

        public static IEnumerable<string> Sentences(int sentenceCount)
        {
            if (sentenceCount <= 0) throw new ArgumentException("Count must be greater than zero", "sentenceCount");

            return sentenceCount.Times(x => Sentence());
        }

        public static string Paragraph(int minSentenceCount)
        {
            if (minSentenceCount <= 0) throw new ArgumentException("Count must be greater than zero", "minSentenceCount");

            return string.Join(" ", Sentences(minSentenceCount + RandomNumber.Next(3)).ToArray());
        }

        public static string Paragraph()
        {
            return Paragraph(3);
        }

        public static IEnumerable<string> Paragraphs(int paragraphCount)
        {
            if (paragraphCount <= 0) throw new ArgumentException("Count must be greater than zero", "paragraphCount");

            return paragraphCount.Times(x => Paragraph());
        }
    }
}