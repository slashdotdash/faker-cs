using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        ///     Gets a random paragraph.
        /// </summary>
        /// <returns>The random paragraph.</returns>
        /// <seealso cref="Paragraph(int)" />
        public static string Paragraph()
        {
            // ReSharper disable once ExceptionNotDocumentedOptional
            return Paragraph(3);
        }

        /// <summary>
        ///     Gets a random paragraph.
        /// </summary>
        /// <param name="minSentenceCount">The minimum sentence count.</param>
        /// <returns>The random paragraph.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Minimum sentence count must be greater than zero.</exception>
        /// <seealso cref="Paragraph()" />
        /// <seealso cref="Sentences(int)" />
        public static string Paragraph(int minSentenceCount)
        {
            if (minSentenceCount <= 0)
            {
                throw new ArgumentOutOfRangeException("minSentenceCount",
                                                      "Minimum sentence count must be greater than zero.");
            }

            return string.Join(" ", Sentences(minSentenceCount + RandomNumber.Next(3)));
        }

        /// <summary>
        ///     Gets a collection of random paragraphs.
        /// </summary>
        /// <param name="paragraphCount">The paragraph count.</param>
        /// <returns>The collection of random paragraphs.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Paragraph Count must be greater than zero</exception>
        /// <seealso cref="Paragraph()" />
        public static IEnumerable<string> Paragraphs(int paragraphCount)
        {
            if (paragraphCount <= 0)
                throw new ArgumentOutOfRangeException("paragraphCount", "Paragraph Count must be greater than zero");

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
        /// <exception cref="ArgumentOutOfRangeException">Minimum word count must be greater than zero</exception>
        /// <seealso cref="Sentence()" />
        /// <seealso cref="Words(int)" />
        public static string Sentence(int minWordCount)
        {
            if (minWordCount <= 0)
                throw new ArgumentOutOfRangeException("minWordCount", "Minimum word count must be greater than zero");

            return string.Join(" ", Words(minWordCount + RandomNumber.Next(6))).Capitalise() + ".";
        }

        /// <summary>
        ///     Gets a collection of random sentences.
        /// </summary>
        /// <param name="sentenceCount">The sentence count.</param>
        /// <returns>A collection of random sentences.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Sentence count must be greater than zero</exception>
        /// <seealso cref="Sentence()" />
        public static IEnumerable<string> Sentences(int sentenceCount)
        {
            if (sentenceCount <= 0)
                throw new ArgumentOutOfRangeException("sentenceCount", "Sentence count must be greater than zero");

            return sentenceCount.Times(x => Sentence());
        }

        /// <summary>
        ///     Gets the specified <paramref name="count" /> of random words.
        /// </summary>
        /// <param name="count">The count of random words.</param>
        /// <returns>An Enumerable of random words.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Count must be greater than zero</exception>
        public static IEnumerable<string> Words(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("count", "Count must be greater than zero");

            return count.Times(x => Resources.Lorem.Words.Split(Config.SEPARATOR).Random());
        }
    }
}
