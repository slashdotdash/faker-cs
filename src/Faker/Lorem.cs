using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of Random sentences/words/paragraphs etc. related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="false" />
    [SuppressMessage("ReSharper", "UseNameofExpression")]
    public static class Lorem
    {
        /// <summary>
        ///     Gets the first word of the random word collection. Useful for unit tests.
        /// </summary>
        /// <returns>The first word of the random word collection.</returns>
        [Obsolete("This would almost be the equivalent of a hard coded word, will not be supported in the future.",
            true)]
        public static string GetFirstWord()
        {
            return Resources.Lorem.Words.Split(Config.SEPARATOR).First();
        }

        /// <summary>
        ///     Gets a random paragraph.
        /// </summary>
        /// <returns>The random paragraph.</returns>
        /// <exception cref="ArgumentException">Minimum Sentence Count must be greater than zero.</exception>
        /// <seealso cref="Paragraph(int)" />
        public static string Paragraph()
        {
            return Paragraph(3);
        }

        /// <summary>
        ///     Gets a random paragraph.
        /// </summary>
        /// <param name="minSentenceCount">The minimum sentence count.</param>
        /// <returns>The random paragraph.</returns>
        /// <exception cref="System.ArgumentException">Minimum Sentence Count must be greater than zero.</exception>
        /// <seealso cref="Paragraph()" />
        /// <seealso cref="Sentences(int)" />
        public static string Paragraph(int minSentenceCount)
        {
            if (minSentenceCount <= 0)
            {
                throw new ArgumentException("Minimum Sentence Count must be greater than zero.",
                                            "minSentenceCount");
            }

            return string.Join(" ", Sentences(minSentenceCount + RandomNumber.Next(3)));
        }

        /// <summary>
        ///     Gets a collection of random paragraphs.
        /// </summary>
        /// <param name="paragraphCount">The paragraph count.</param>
        /// <returns>The collection of random paragraphs.</returns>
        /// <exception cref="System.ArgumentException">Paragraph Count must be greater than zero</exception>
        /// <seealso cref="Paragraph()" />
        public static IEnumerable<string> Paragraphs(int paragraphCount)
        {
            if (paragraphCount <= 0)
                throw new ArgumentException("Paragraph Count must be greater than zero", "paragraphCount");

            return paragraphCount.Times(x => Paragraph());
        }

        /// <summary>
        ///     Gets a random sentence.
        /// </summary>
        /// <returns>The random sentence.</returns>
        /// <seealso cref="Sentence(int)" />
        public static string Sentence()
        {
            // ReSharper disable once ExceptionNotDocumentedOptional
            return Sentence(4);
        }

        /// <summary>
        ///     Gets a random sentence.
        /// </summary>
        /// <param name="minWordCount">The minimum word count.</param>
        /// <returns>The random sentence</returns>
        /// <exception cref="System.ArgumentException">Minimum word count must be greater than zero</exception>
        /// <seealso cref="Sentence()" />
        /// <seealso cref="Words(int)" />
        public static string Sentence(int minWordCount)
        {
            if (minWordCount <= 0)
                throw new ArgumentException("Minimum word count must be greater than zero", "minWordCount");

            return string.Join(" ", Words(minWordCount + RandomNumber.Next(6)).ToArray()).Capitalise() + ".";
        }

        /// <summary>
        ///     Gets a collection of random sentences.
        /// </summary>
        /// <param name="sentenceCount">The sentence count.</param>
        /// <returns>A collection of random sentences.</returns>
        /// <exception cref="System.ArgumentException">Sentence count must be greater than zero</exception>
        /// <seealso cref="Sentence()" />
        public static IEnumerable<string> Sentences(int sentenceCount)
        {
            if (sentenceCount <= 0)
                throw new ArgumentException("Sentence count must be greater than zero", "sentenceCount");

            return sentenceCount.Times(x => Sentence());
        }

        /// <summary>
        ///     Gets the specified <paramref name="count" /> of random words.
        /// </summary>
        /// <param name="count">The count of random words.</param>
        /// <returns>An Enumerable of random words.</returns>
        /// <exception cref="ArgumentException">Count must be greater than zero</exception>
        public static IEnumerable<string> Words(int count)
        {
            if (count <= 0)
                throw new ArgumentException("Count must be greater than zero", "count");

            return count.Times(x => Resources.Lorem.Words.Split(Config.SEPARATOR).Random());
        }
    }
}
