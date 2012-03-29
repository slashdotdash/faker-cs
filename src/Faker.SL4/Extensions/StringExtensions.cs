using System.Text.RegularExpressions;

namespace Faker.Extensions
{
    public static class StringExtensions
    {
        private static readonly string[] _alphabet = "a b c d e f g h i j k l m n o p q r s t u v w x y z".Split(' ');

        /// <summary>
        /// Get a string with every occurence of '#' replaced with a random number.
        /// </summary>
        public static string Numerify(this string s)
        {
            return Regex.Replace(s, "#", new MatchEvaluator((m) => RandomNumber.Next(0, 9).ToString()));
        }

        /// <summary>
        /// Get a string with every '?' replaced with a random character from the alphabet.
        /// </summary>
        public static string Letterify(this string s)
        {
            return Regex.Replace(s, @"\?", new MatchEvaluator((m) => _alphabet.Random()));
        }

        public static string AlphanumericOnly(this string s)
        {
            return Regex.Replace(s, @"\W", "");
        }

        /// <summary>
        /// Capitalise the first letter of the given string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Capitalise(this string s)
        {
            return Regex.Replace(s, "^[a-z]", new MatchEvaluator(x => x.Value.ToUpperInvariant()));
        }
    }
}