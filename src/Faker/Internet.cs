using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Faker.Extensions;

namespace Faker
{
    /// <summary>
    ///     A collection of address related resources.
    /// </summary>
    /// <include file='Docs/CustomRemarks.xml' path='Comments/SatelliteResource/*' />
    /// <threadsafety static="true" />
    public static class Internet
    {
        private static readonly object s_userNameFormatLock = new object();

        private static readonly IEnumerable<Func<string>> s_userNameFormats = new Func<string>[]
        {
            () => Name.First().AlphanumericOnly(),
            () => Name.First().AlphanumericOnly()
                  + new[] {".", "_"}.Random()
                  + Name.Last().AlphanumericOnly()
        };

        /// <summary>
        ///     Generates the name of a random domain.
        /// </summary>
        /// <returns>The random domain name.</returns>
        public static string DomainName()
        {
            var prefix = new[] {string.Empty, string.Empty, "www.", "www2."};

            return prefix.Random() + DomainNameWithoutPrefix();
        }

        /// <summary>
        ///     Generates a random domain suffix (ex. com,net,info etc.).
        /// </summary>
        /// <returns>A random Domain suffix.</returns>
        public static string DomainSuffix()
        {
            return Resources.Internet.DomainSuffix.Split(Config.SEPARATOR).Random();
        }

        /// <summary>
        ///     Generates a random domain word.
        /// </summary>
        /// <returns>The random domain word.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public static string DomainWord()
        {
            return Company.Name().Split(' ').First().AlphanumericOnly().ToLowerInvariant();
        }

        /// <summary>
        ///     Generates a random email address.
        /// </summary>
        /// <returns>A random email address.</returns>
        public static string Email()
        {
            return "{0}@{1}".FormatCulture(UserName(), DomainNameWithoutPrefix());
        }

        /// <summary>
        ///     Generates a random email address.
        /// </summary>
        /// <param name="name">The name to generate the username from.</param>
        /// <returns>The random email address, with the generated username.</returns>
        public static string Email(string name)
        {
            return "{0}@{1}".FormatCulture(UserName(name), DomainNameWithoutPrefix());
        }

        /// <summary>
        ///     Generates a random free email address.
        /// </summary>
        /// <returns>The random free email address.</returns>
        /// <example>
        ///     <code language="cs">
        /// var email = Faker.Internet.FreeEmail();
        /// 
        /// Console.WriteLine("Result = " + email);
        /// // Result = abe.linky@gmail.com
        /// </code>
        /// </example>
        public static string FreeEmail()
        {
            return "{0}@{1}".FormatCulture(UserName(), Resources.Internet.FreeMail.RandomResource());
        }

        /// <summary>
        ///     Gets a random ip v4 address.
        /// </summary>
        /// <returns>A random ip v4 address.</returns>
        // ReSharper disable once InconsistentNaming
        public static string IPv4Address()
        {
            const int min = 2;
            const int max = 255;

            return string.Join(".", 4.Times(c => RandomNumber.Next(min, max).ToString(CultureInfo.CurrentCulture)));
        }

        /// <summary>
        ///     Gets a random ip v6 address.
        /// </summary>
        /// <returns>A random ip v6 address.</returns>
        // ReSharper disable once InconsistentNaming
        public static string IPv6Address()
        {
            const int min = 0;
            const int max = 65536;

            return string.Join(":", 8.Times(c => RandomNumber.Next(min, max).ToString("x", CultureInfo.CurrentCulture)));
        }

        /// <summary>
        ///     Gets a random mac address.
        /// </summary>
        /// <param name="prefix">The prefix.</param>
        /// <param name="groupSplit">The group split.</param>
        /// <returns>The random mac address.</returns>
        public static string MacAddress(string prefix = null, char groupSplit = ':')
        {
            const int maxBufferLength = 6;

            int prefixesLength = prefix == null ? 0 : prefix.Split(groupSplit).Length;
            if (prefix != null && prefixesLength < maxBufferLength
                && !prefix.EndsWith(groupSplit.ToString(), StringComparison.CurrentCulture))
                prefix += groupSplit;

            var buffer = new byte[maxBufferLength - prefixesLength];
            RandomNumber.NextBytes(buffer);
            string result = string.Concat(buffer.Select(x => x.ToString("X2", CultureInfo.CurrentCulture) + groupSplit));

            return prefix + result.TrimEnd(groupSplit);
        }

        /// <summary>
        ///     Gets a random password.
        /// </summary>
        /// <param name="minLength">The minimum length.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <returns>The random password.</returns>
        public static string Password(int minLength, int maxLength)
        {
            string result = Lorem.Characters(minLength);
            int difference = RandomNumber.Next(maxLength - minLength + 1);

            if (difference > 0)
                result += Lorem.Characters(difference);

            return result;
        }

        /// <summary>
        ///     Gets a random slug.
        /// </summary>
        /// <param name="words">The words.</param>
        /// <param name="glue">The glue.</param>
        /// <returns>The slug.</returns>
        public static string Slug(string words = null, string glue = null)
        {
            glue = glue ?? new[] {"_", ".", "-"}.Random();

            return (words ?? string.Join(" ", Lorem.Words(2))).Replace(" ", glue).ToLower();
        }

        /// <summary>
        ///     Gets a random URL.
        /// </summary>
        /// <returns>A random URL.</returns>
        public static string Url()
        {
            string protocol = new[] {"http", "https"}.Random();
            return "{0}://{1}/{2}".FormatCulture(protocol, DomainName(), UserName());
        }

        /// <summary>
        ///     Generates a random username.
        /// </summary>
        /// <returns>The random username.</returns>
        public static string UserName()
        {
            lock (s_userNameFormatLock)
            {
                return UserName(s_userNameFormats.Random());
            }
        }

        /// <summary>
        ///     Generates a random username.
        /// </summary>
        /// <param name="name">The name to generate the user name from.</param>
        /// <returns>The generated username.</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public static string UserName(string name)
        {
            return Regex.Replace(name, @"[^\w]+", x => new[] {".", "_"}.Random()).ToLowerInvariant();
        }

        private static string DomainNameWithoutPrefix()
        {
            return "{0}.{1}".FormatCulture(DomainWord(), DomainSuffix());
        }
    }
}
