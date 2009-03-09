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

            return count.Times(x => _words.Random());
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

        private static readonly string[] _words = "alias consequatur aut perferendis sit voluptatem accusantium doloremque aperiam eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo aspernatur aut odit aut fugit sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt neque dolorem ipsum quia dolor sit amet consectetur adipisci velit sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem ut enim ad minima veniam quis nostrum exercitationem ullam corporis nemo enim ipsam voluptatem quia voluptas sit suscipit laboriosam nisi ut aliquid ex ea commodi consequatur quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae et iusto odio dignissimos ducimus qui blanditiis praesentium laudantium totam rem voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident sed ut perspiciatis unde omnis iste natus error similique sunt in culpa qui officia deserunt mollitia animi id est laborum et dolorum fuga et harum quidem rerum facilis est et expedita distinctio nam libero tempore cum soluta nobis est eligendi optio cumque nihil impedit quo porro quisquam est qui minus id quod maxime placeat facere possimus omnis voluptas assumenda est omnis dolor repellendus temporibus autem quibusdam et aut consequatur vel illum qui dolorem eum fugiat quo voluptas nulla pariatur at vero eos et accusamus officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae itaque earum rerum hic tenetur a sapiente delectus ut aut reiciendis voluptatibus maiores doloribus asperiores repellat".Split(' ');
    }
}