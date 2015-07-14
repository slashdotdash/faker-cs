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
            var prefix = new[] {string.Empty, "www.", "www2."};
            return "{0}{1}.{2}".FormatCulture(prefix.Random(), DomainWord(), DomainSuffix());
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
            return "{0}@{1}".FormatCulture(UserName(), DomainName());
        }

        /// <summary>
        ///     Generates a random email address.
        /// </summary>
        /// <param name="name">The name to generate the username from.</param>
        /// <returns>The random email address, with the generated username.</returns>
        public static string Email(string name)
        {
            return "{0}@{1}".FormatCulture(UserName(name), DomainName());
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
    }
}
