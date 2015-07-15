using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Faker.JetBrains.Annotations;

namespace Faker.Extensions
{
    /// <summary>
    ///     A collection of string helper extensions.
    /// </summary>
    /// <threadsafety static="true" />
    public static class StringExtensions
    {
        private const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";
        private static readonly object s_dictionaryLock = new object();
        private static readonly IDictionary<string, Func<string>> s_validVariables;

        static StringExtensions()
        {

            lock (s_dictionaryLock)
            {
                s_validVariables = new Dictionary<string, Func<string>>();

                AddVariables(typeof (Address), s_validVariables);
                AddVariables(typeof (Company), s_validVariables);
                AddVariables(typeof (Name), s_validVariables);
                s_validVariables.Add("StreetRoot", Resources.Address.StreetRoot.RandomResource);
                s_validVariables.Add("CityRoot", Resources.Address.CityRoot.RandomResource);
                s_validVariables.Add("CommonStreetSuffixes", Resources.Address.CommonStreetSuffixes.RandomResource);
                s_validVariables.Add("AreaCode", Resources.Phone.AreaCode.RandomResource);
                s_validVariables.Add("ExchangeCode", Resources.Phone.ExchangeCode.RandomResource);
            }
        }

        /// <summary>
        ///     Removes all characters which is not Alphanumeric from the specified <paramref name="s">source</paramref>
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <returns>The transformed string.</returns>
        public static string AlphanumericOnly(this string s)
        {
            return Regex.Replace(s, @"\W", string.Empty);
        }

        /// <summary>
        ///     Capitalises the first letter of the given string.
        /// </summary>
        /// <param name="s">The source string.</param>
        /// <returns>The source string with it's first letter capitalized.</returns>
        public static string Capitalise(this string s)
        {
            return Regex.Replace(s, "^[a-z]", x => x.Value.ToUpperInvariant());
        }

        /// <summary>
        ///     Helper function for formatting a string with the current <see cref="CultureInfo" />
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formatted string.</returns>
        [NotNull]
        [Pure]
        [StringFormatMethod("format")]
        public static string FormatCulture([NotNull] this string format, [NotNull] params object[] args)
        {
            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

        /// <summary>
        ///     Helper function for formatting string with an invariant <see cref="CultureInfo" />.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>The formatted string.</returns>
        [NotNull]
        [Pure]
        [StringFormatMethod("format")]
        public static string FormatInvariant([NotNull] this string format, [NotNull] params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }

        /// <summary>
        ///     Get a string with every '?' replaced with a random character from the english alphabet.
        /// </summary>
        /// <param name="s">The source format</param>
        /// <returns>The formatted string.</returns>
        public static string Letterify(this string s)
        {
            return new string(Transform(s, true, false).ToArray());
        }

        /// <summary>
        ///     Get a string with every occurrence of '#' replaced with a random number.
        /// </summary>
        /// <param name="s">The source format.</param>
        /// <returns>The formatted string.</returns>
        public static string Numerify(this string s)
        {
            return new string(Transform(s, false, true).ToArray());
        }

        /// <summary>
        ///     Transforms the specified source and conditionally replaces variables.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="replaceVariables">if set to <see langword="true" /> replace variables in the string.</param>
        /// <returns>The transformed string.</returns>
        public static string Transform(this string s, bool replaceVariables = false)
        {
            char[] currentChars = Transform(s, true, true).ToArray();

            if (!replaceVariables)
                return new string(currentChars);

            var builder = new StringBuilder();

            for (var index = 0; index < currentChars.Length; index++)
            {
                char c = currentChars[index];

                if (c == '{' && char.IsLetter(currentChars[++index]))
                {
                    string value = GetVariableValue(currentChars, ref index);
                    builder.Append(value);
                }
                else
                    builder.Append(c);
            }

            return builder.ToString();
        }

        private static void AddVariables(Type classType, IDictionary<string, Func<string>> validVariables)
        {
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Static);

            foreach (MethodInfo methodInfo in
                methods
                    .Where(
                           methodInfo =>
                           methodInfo.ReturnType == typeof (string)
                           && !methodInfo.GetParameters().Any()))
            {
                validVariables.Add(
                                   classType.Name + "." + methodInfo.Name,
                                   () => (string) methodInfo.Invoke(null, null)
                    );
            }
        }

        private static string GetVariable(IList<char> chars, ref int index)
        {
            var substring = new StringBuilder();

            while (chars.Count >= index && chars[index] != '}')
                substring.Append(chars[index++]);

            return substring.ToString();
        }

        private static string GetVariableValue(IList<char> chars, ref int index)
        {
            string variable = GetVariable(chars, ref index);

            lock (s_dictionaryLock)
            {
                return s_validVariables.ContainsKey(variable) ? s_validVariables[variable].Invoke() : string.Empty;
            }
        }

        private static IEnumerable<char> Transform(string s, bool letterify, bool numerify)
        {
            foreach (char c in s)
            {
                if (numerify && c == '#')
                    yield return RandomNumber.Next(0, 10).ToString()[0];
                else if (letterify && c == '?')
                    yield return ALPHABET.Random();
                else
                    yield return c;
            }
        }
    }
}
